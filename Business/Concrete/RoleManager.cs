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
    public class RoleManager:IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult();
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult();
        }

        public IDataResult<List<Role>> GetAll()
        {
            var result = _roleDal.GetAll();
            return new SuccessDataResult<List<Role>>(result);
        }
    }
}
