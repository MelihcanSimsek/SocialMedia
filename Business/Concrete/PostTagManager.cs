using Business.Abstract;
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
    public class PostTagManager:IPostTagService
    {
        IPostTagDal _postTagDal;
        public PostTagManager(IPostTagDal postTagDal)
        {
            _postTagDal = postTagDal;
        }

        public IResult Add(PostTag postTag)
        {
            _postTagDal.Add(postTag);
            return new SuccessResult();
        }

        public IResult Delete(PostTag postTag)
        {
            _postTagDal.Delete(postTag);
            return new SuccessResult();
        }

        public IDataResult<PostTag> GetPostTagByPostId(int id)
        {
            var result = _postTagDal.Get(p => p.PostId == id);
            return new SuccessDataResult<PostTag>(result);
        }

        public IResult Update(PostTag postTag)
        {
            _postTagDal.Update(postTag);
            return new SuccessResult();
        }
    }
}
