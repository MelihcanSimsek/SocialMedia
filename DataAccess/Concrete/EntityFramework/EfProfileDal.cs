using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProfileDal : EfEntityFrameworkBase<Profile, SocialMediaContext>, IProfileDal
    {
        public UserProfileDto GetUserProfile(int id)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from user in context.Users
                             join profile in context.Profiles
                             on user.Id equals profile.UserId
                             where user.Id == id
                             select new UserProfileDto
                             {
                                 Id = profile.Id,
                                 UserId = user.Id,
                                 BackgroundImage = profile.BackgroundImage,
                                 CreationDate = user.CreationDate,
                                 Name = user.Name,
                                 ProfileImage = profile.ProfileImage,
                                 Description = profile.Description,
                                 Location = profile.Location,
                                 ProfileStatus = profile.Status,
                                 UserStatus = user.Status
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
