using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.PostAdded);
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }

        public IDataResult<List<Post>> GetAll()
        {
            var result = _postDal.GetAll();
            return new SuccessDataResult<List<Post>>(result);
        }

        public IDataResult<Post> GetPostById(int id)
        {
            var result = _postDal.Get(p => p.Id == id);
            return new SuccessDataResult<Post>(result);
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
    }
}
