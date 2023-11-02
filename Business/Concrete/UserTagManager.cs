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
    public class UserTagManager : IUserTagService
    {
        IUserTagDal _userTagDal;

        public UserTagManager(IUserTagDal userTagDal)
        {
            _userTagDal = userTagDal;
        }
        public IResult Add(UserTag userTag)
        {
            _userTagDal.Add(userTag);
            return new SuccessResult();
        }

        public IResult Delete(UserTag userTag)
        {
            _userTagDal.Delete(userTag);
            return new SuccessResult();
        }

        public IDataResult<List<UserTag>> GetAllUserTagByUserId(int id)
        {
            var result = _userTagDal.GetAll(u => u.UserId == id);
            return new SuccessDataResult<List<UserTag>>(result);
        }

        public IResult Update(UserTag userTag)
        {
            _userTagDal.Update(userTag);
            return new SuccessResult();
        }
    }
}
