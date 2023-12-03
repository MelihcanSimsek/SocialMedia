using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        IResult Add(Role role);
        IResult Delete(Role role);
        IDataResult<List<Role>> GetAll();
    }
}
