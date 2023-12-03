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
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
            
        }

        public IResult Add(IFormFile file,Post post)
        {
           if(file != null)
            {
                post.ImagePath = FileHelper.Add(file);
            }
            post.CreationDate = DateTime.Now;
            _postDal.Add(post);
            return new SuccessResult(Messages.PostAdded);
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

        public IDataResult<List<PostDetailDto>> GetAllCommentByPostId(int id)
        {
            var result = _postDal.GetPostDetails(p => p.ParentId == id && p.Status == true);
            result.Reverse();
            return new SuccessDataResult<List<PostDetailDto>>(result);
        }

       

        public IDataResult<List<PostDetailDto>> GetAllPostDetail()
        {
            var result = _postDal.GetPostDetails(p=>p.ParentId == 0 && p.Status == true);
            result.Reverse();
            return new SuccessDataResult<List<PostDetailDto>>(result);
        }

        public IDataResult<List<Post>> GetAllUserPost(int id)
        {
            var result = _postDal.GetAll(p => p.UserId == id);
            return new SuccessDataResult<List<Post>>(result);
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
