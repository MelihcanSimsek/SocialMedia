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
    public class EfFollowerDal : EfEntityFrameworkBase<Follower, SocialMediaContext>, IFollowerDal
    {
        public UserFollowerDto GetUser(int id)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from user in context.Users
                             join profile in context.Profiles
                             on user.Id equals profile.UserId
                             where user.Id == id
                             select new UserFollowerDto
                             {
                                 UserId = user.Id,
                                 CreationDate = user.CreationDate,
                                 Name = user.Name,
                                 ProfileImage = profile.ProfileImage,
                                 ProfileStatus = profile.Status,
                                 UserStatus = user.Status
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
