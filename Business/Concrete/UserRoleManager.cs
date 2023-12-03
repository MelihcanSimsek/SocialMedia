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
    public class UserRoleManager:IUserRoleService
    {

        IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public IResult Add(UserRole userRole)
        {
            _userRoleDal.Add(userRole);
            return new SuccessResult();
        }

        public IResult Delete(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
            return new SuccessResult();
        }
    }
}
