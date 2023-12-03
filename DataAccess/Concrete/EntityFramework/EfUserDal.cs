
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityFrameworkBase<User, SocialMediaContext>, IUserDal
    {
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
    }
}
