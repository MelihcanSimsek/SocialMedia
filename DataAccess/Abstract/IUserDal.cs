using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<Role> GetRoles(User user);
        List<UserBanDto> GetUserProfileDetails(Expression<Func<UserBanDto, bool>>? filter = null);
        List<UserProfileDto> GetAllUserProfiles(Expression<Func<UserProfileDto, bool>>? filter = null);
    }
}
