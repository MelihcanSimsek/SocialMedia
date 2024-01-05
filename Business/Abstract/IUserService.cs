using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IResult Ban(int id);
        IResult Unban(int id);
        IDataResult<List<UserBanDto>> GetBannedUsers();
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<Role>> GetRoles(User user);
        IDataResult<User> ChangeUserName(string name, int id);
        IDataResult<List<UserProfileDto>> SearchUser(string filter,int currentPage,int perPageNumber );
        IDataResult<int> GetSearchUserTotalCount(string filter);
    }
}
