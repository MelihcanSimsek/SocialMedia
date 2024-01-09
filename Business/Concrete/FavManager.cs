
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FavManager : IFavService
    {
        IFavDal _favDal;
        IPostDal _postDal;

        public FavManager(IFavDal favDal, IPostDal postDal)
        {
            _favDal = favDal;
            _postDal = postDal;
        }
        public IResult Add(Fav fav)
        {
            fav.CreationDate = DateTime.Now;
            _favDal.Add(fav);
            return new SuccessResult();
        }

        public IResult Delete(Fav fav)
        {
            var result = _favDal.Get(f => f.PostId == fav.PostId && f.UserId == fav.UserId);
         
            _favDal.Delete(result);
            return new SuccessResult();
        }

        public IResult DeleteAllUserFav(int id)
        {
            var result = _favDal.GetAll(f => f.UserId == id);
            if(result != null)
            {
                foreach (var r in result)
                {
                    _favDal.Delete(r);
                }
            }
            return new SuccessResult();
        }

        public IDataResult<List<int>> GetPostCommentsFav(int userId, int postId)
        {
            var commentIds = _postDal.GetAll(p => p.ParentId == postId).Select(p => p.Id).ToList();
            var favs = _favDal.GetAll(f => f.UserId == userId);
            var intersectIds = favs.Select(f => f.PostId).ToList().Intersect(commentIds).ToList();
            if (favs.Any(f => f.PostId == postId))
            {
                intersectIds.Add(postId);
            }
            return new SuccessDataResult<List<int>>(intersectIds);
        }

        public IDataResult<int> GetPostFavNumber(int postid)
        {
            var result = _favDal.GetAll(p => p.PostId == postid);
            return new SuccessDataResult<int>(result.Count);
        }

        public IDataResult<List<int>> GetUserCommentsFavs(int userId, int targetId)
        {
            var postIds = _postDal.GetAll(p => p.UserId == targetId && p.ParentId != 0).Select(p => p.Id).ToList();
            var favPostIds = _favDal.GetAll(p => p.UserId == userId).Select(p => p.PostId).ToList();
            var intersectIds = favPostIds.Intersect(postIds).ToList();

            return new SuccessDataResult<List<int>>(intersectIds);
        }

        public IDataResult<List<int>> GetUserFavedPosts(int id)
        {
            var result = _favDal.GetAll(f => f.UserId == id).Select(p=>p.PostId).ToList();
            return new SuccessDataResult<List<int>>(result);
        }

        public IDataResult<List<int>> GetUserFavPostsFavs(int userId, int targetId)
        {
            var targetUserFavPostTable = _favDal.GetAll(p => p.UserId == targetId).Select(p => p.PostId).ToList();
            var favPostIds = _favDal.GetAll(p => p.UserId == userId).Select(p => p.PostId).ToList();

            var intersectIds = favPostIds.Intersect(targetUserFavPostTable).ToList();
            return new SuccessDataResult<List<int>>(intersectIds);
        }

        public IDataResult<List<int>> GetUserPostsFavs(int userId,int targetId)
        {
            var postIds = _postDal.GetAll(p => p.UserId == targetId && p.ParentId == 0).Select(p => p.Id).ToList();
            var favPostIds = _favDal.GetAll(p => p.UserId == userId).Select(p => p.PostId).ToList();
            var intersectIds = favPostIds.Intersect(postIds).ToList();

            return new SuccessDataResult<List<int>>(intersectIds);
        }

        public IResult Update(Fav fav)
        {
            _favDal.Update(fav);
            return new SuccessResult();
        }
    }
}
