using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserTagService
    {
        IResult Add(UserTag userTag);
        IResult Delete(UserTag userTag);
        IResult Update(UserTag userTag);
        IResult CheckUserAlreadyHasAPostLabel(UserTag userTag);
        IDataResult<List<UserTag>> GetAllUserTagByUserId(int id);
        IDataResult<List<string>> GetAllUserLabelForWeekByUserId(int id);

    }
}
