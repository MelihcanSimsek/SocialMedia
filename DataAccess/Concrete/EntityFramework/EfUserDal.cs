
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityFrameworkBase<User, SocialMediaContext>, IUserDal
    {
        public List<UserProfileDto> GetAllUserProfiles(Expression<Func<UserProfileDto, bool>>? filter = null)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from user in context.Users
                             join profile in context.Profiles
                             on user.Id equals profile.UserId
                             select new UserProfileDto
                             {
                                 UserId = user.Id,
                                 Id = user.Id,
                                 BackgroundImage = profile.BackgroundImage,
                                 CreationDate = user.CreationDate,
                                 Description = profile.Description,
                                 Location = profile.Location,
                                 Name = user.Name,
                                 ProfileImage = profile.ProfileImage,
                                 ProfileStatus = profile.Status,
                                 UserStatus = user.Status
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<Role> GetRoles(User user)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                             on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id = role.Id, Name=role.Name };

                return result.ToList();
            }
        }

        public List<UserBanDto> GetUserProfileDetails(Expression<Func<UserBanDto, bool>>? filter = null)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from user in context.Users
                             join profile in context.Profiles
                             on user.Id equals profile.UserId
                             select new UserBanDto
                             {
                                 UserId = user.Id,
                                 BanDate = user.BanDate,
                                 ImagePath = profile.ProfileImage,
                                 Status = user.Status,
                                 UserName = user.Name
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
