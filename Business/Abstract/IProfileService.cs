
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProfileService
    {
        IResult Add(Profile profile);
        IResult Delete(Profile profile);
        IResult Update(Profile profile);
        IDataResult<Profile> GetProfileByUserId(int id);
    }
}
