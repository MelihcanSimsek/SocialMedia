using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager:IPostService
    {
        IPostDal _postDal;
        IFavService _favService;
        IFollowerService _followerService;
        IUserTagService _userTagService;
        public PostManager(IPostDal postDal, IFavService favService, IFollowerService followerService,IUserTagService userTagService)
        {
            _postDal = postDal;
            _favService = favService;
            _followerService = followerService;
            _userTagService = userTagService;
            
        }

        public IDataResult<int> Add(IFormFile file,Post post)
        {
           if(file != null)
            {
                post.ImagePath = FileHelper.Add(file);
            }
            post.CreationDate = DateTime.Now;
            _postDal.Add(post);

            var postId = _postDal.Get(p =>
                                p.CreationDate > DateTime.Now.AddSeconds(-10) &&
                                p.UserId == post.UserId &&
                                p.ParentId == post.ParentId &&
                                p.ImagePath == post.ImagePath &&
                                p.Type == post.Type
                            )?.Id ?? 0;
            return new SuccessDataResult<int>(postId,Messages.PostAdded);
        }

        public IResult Delete(Post post)
        {
            var result = _postDal.Get(p=>p.Id == post.Id);
            _postDal.Delete(result);
            return new SuccessResult(Messages.PostDeleted);
        }

        public IResult DeleteAllUserPost(int id)
        {
            var result = _postDal.GetAll(p => p.UserId == id);

            if(result != null)
            {
                foreach (var r in result)
                {
                    _postDal.Delete(r);
                    
                }
            }
            
            return new SuccessResult();
        }

        public IDataResult<List<Post>> GetAll()
        {
            var result = _postDal.GetAll();
            return new SuccessDataResult<List<Post>>(result);
        }

        public IDataResult<List<PostDetailDto>> GetAllCommentByPostId(int id,int userId)
        {
            var followedUserIds = _followerService.GetAllFollowedUseridByUserId(userId).Data;
            var allPosts = _postDal.GetPostDetails(p => p.ParentId == id && p.Status == true);
            var sortedPosts = GetBestOfPosts(allPosts);
            var nonFollowedPosts = sortedPosts.Where(p => !followedUserIds.Contains(p.UserId)).ToList();
            var followedPosts = sortedPosts.Where(p => followedUserIds.Contains(p.UserId)).OrderByDescending(p => p.CreationDate).ToList();
            var concatenatedPosts = followedPosts.Concat(nonFollowedPosts).ToList();
            return new SuccessDataResult<List<PostDetailDto>>(concatenatedPosts);
        }

        public IDataResult<List<PostDetailDto>> GetAllFavedPostUserId(int id)
        {
            List<PostDetailDto> favedPost = new List<PostDetailDto>();
            var favedList = _favService.GetUserFavedPosts(id).Data;
            foreach (var postid in favedList)
            {
                var data = _postDal.GetPostDetails(p => p.Id == postid).SingleOrDefault();
                favedPost.Add(data);
            }

            var result =  favedPost.OrderByDescending(p => p.CreationDate).ToList();
            return new SuccessDataResult<List<PostDetailDto>>(result);
        }

        public IDataResult<List<PostDetailDto>> GetAllPostDetail(int userId)
        {
            var userLabels = _userTagService.GetAllUserLabelForWeekByUserId(userId).Data;
            var allUnionPosts = new List<PostDetailDto>();
            if(userLabels.Count > 0)
            {
                var followedUserIds = _followerService.GetAllFollowedUseridByUserId(userId).Data;
                var allPosts = _postDal.GetPostDetails(p => p.ParentId == 0 && p.Status == true && p.CreationDate >= DateTime.Now.AddDays(-1).Date);
                var nonFollowedPosts = allPosts.Where(p => !followedUserIds.Contains(p.UserId)).ToList();
                var followedPosts = allPosts.Where(p => followedUserIds.Contains(p.UserId)).ToList();
                var selectedNonFollowedPosts = SelectUserNonFollowedPostsWithUserLabels(nonFollowedPosts, userLabels).Take(25);
                var selectedFollowedPosts = SelectUserNonFollowedPostsWithUserLabels(followedPosts, userLabels).Take(25);
                var zippedPosts = selectedFollowedPosts.Zip(selectedNonFollowedPosts, (followed, nonFollowed) => new List<PostDetailDto> { followed, nonFollowed })
                        .SelectMany(pair => pair)
                        .ToList();

                // Eğer her iki listeden de tüm öğeler eşit şekilde eşlendiğinde, fazla olan öğeler sonuç listesine eklenir
                if (selectedFollowedPosts.Count() > selectedNonFollowedPosts.Count())
                {
                    var additionalPosts = selectedFollowedPosts.Skip(selectedNonFollowedPosts.Count());
                    allUnionPosts = zippedPosts.Concat(additionalPosts).ToList();
                }
                else if (selectedNonFollowedPosts.Count() > selectedFollowedPosts.Count())
                {
                    var additionalPosts = selectedNonFollowedPosts.Skip(selectedFollowedPosts.Count());
                    allUnionPosts = zippedPosts.Concat(additionalPosts).ToList();
                }
                else
                {
                    allUnionPosts = zippedPosts;
                }
            }
            else
            {
                var followedUserIds = _followerService.GetAllFollowedUseridByUserId(userId).Data;
                var allPosts = _postDal.GetPostDetails(p => p.ParentId == 0 && p.Status == true && p.CreationDate >= DateTime.Now.AddDays(-1).Date);
                var sortedPosts = GetBestOfPosts(allPosts);
                var nonFollowedPosts = sortedPosts.Where(p => !followedUserIds.Contains(p.UserId)).Take(25);
                var followedPosts = sortedPosts.Where(p => followedUserIds.Contains(p.UserId)).Take(25);
                var zippedPosts = followedPosts.Zip(nonFollowedPosts, (followed, nonFollowed) => new List<PostDetailDto> { followed, nonFollowed })
                        .SelectMany(pair => pair)
                        .ToList();

                // Eğer her iki listeden de tüm öğeler eşit şekilde eşlendiğinde, fazla olan öğeler sonuç listesine eklenir
                if (followedPosts.Count() > nonFollowedPosts.Count())
                {
                    var additionalPosts = followedPosts.Skip(nonFollowedPosts.Count());
                    allUnionPosts = zippedPosts.Concat(additionalPosts).ToList();
                }
                else if (nonFollowedPosts.Count() > followedPosts.Count())
                {
                    var additionalPosts = nonFollowedPosts.Skip(followedPosts.Count());
                    allUnionPosts = zippedPosts.Concat(additionalPosts).ToList();
                }
                else
                {
                    allUnionPosts = zippedPosts;
                }
            }
           
            var HourlyPosts = new List<PostDetailDto>();
            var restOfPosts = new List<PostDetailDto>();

            foreach (var post in allUnionPosts)
            {
                if (post.CreationDate > DateTime.Now.AddHours(-1))
                {
                    HourlyPosts.Add(post);
                }
                else
                {
                    restOfPosts.Add(post);

                }
            }

            var concatenatedPosts = HourlyPosts.Concat(restOfPosts).ToList();
            return new SuccessDataResult<List<PostDetailDto>>(concatenatedPosts);
        }

        private List<PostDetailDto> SelectUserNonFollowedPostsWithUserLabels(List<PostDetailDto> nonFollowedPosts,List<string> labels)
        {
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            foreach (var label in labels)
            {
                if (wordFreq.ContainsKey(label.Trim()))
                {
                    wordFreq[label.Trim()]++;
                }
                else
                {
                    wordFreq[label.Trim()] = 1;
                }
            }
          
            var userInterestedPosts = nonFollowedPosts.Select(p => new
            {
                Post = p,
                Score = wordFreq.ContainsKey(p.Label.Trim()) == true ? wordFreq[p.Label.Trim()] * (p.Fav.Length+p.Comment+1) +p.Fav.Length*3+ p.Comment*5 : 0
            }).ToList();

            var newNonFollowedPosts = userInterestedPosts.OrderByDescending(p => p.Score).Select(p => p.Post).ToList();

            return newNonFollowedPosts;
        }

        private List<PostDetailDto> GetBestOfPosts(List<PostDetailDto> allPosts)
        {
            var bestOfPosts = allPosts.Select(p => new
            {
                Post = p,
                Score = p.Fav.Length * 3  + p.Comment * 5
            }).ToList();
            var sortedPosts = bestOfPosts.OrderByDescending(p => p.Score).Select(p => p.Post).ToList();
            return sortedPosts;
        }

        public IDataResult<List<PostDetailDto>> GetAllUserComment(int id)
        {
            var result = _postDal.GetPostDetails(p => p.UserId == id && p.ParentId != 0).OrderByDescending(p=>p.CreationDate).ToList();
            return new SuccessDataResult<List<PostDetailDto>>(result);
        }

        public IDataResult<List<PostDetailDto>> GetAllUserPost(int id)
        {
            var result = _postDal.GetPostDetails(p => p.UserId == id && p.ParentId == 0).OrderByDescending(p=>p.CreationDate).ToList();
            return new SuccessDataResult<List<PostDetailDto>>(result);
        }

        public IDataResult<List<PostDetailDto>> GetAllPostDetailByUserId(int id)
        {
            var result = _postDal.GetPostDetails(p => p.UserId == id);
            return new SuccessDataResult<List<PostDetailDto>>(result);
        }

        public IDataResult<Post> GetPostById(int id)
        {
            var result = _postDal.Get(p => p.Id == id);
            return new SuccessDataResult<Post>(result);
        }

        public IDataResult<PostDetailDto> GetPostDetailById(int id)
        {
            var result = _postDal.GetPostDetails(p => p.Id == id).SingleOrDefault();
            return new SuccessDataResult<PostDetailDto>(result);
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
    }
}
