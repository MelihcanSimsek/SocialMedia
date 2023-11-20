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
    public class EfPostDal : EfEntityFrameworkBase<Post, SocialMediaContext>, IPostDal
    {
        public List<PostDetailDto> GetPostDetails(Expression<Func<PostDetailDto, bool>>? filter = null)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from post in context.Posts
                             join user in context.Users
                             on post.UserId equals user.Id
                             join profile in context.Profiles
                             on user.Id equals profile.UserId
                             select new PostDetailDto
                             {
                                 Id = post.Id,
                                 ImagePath = post.ImagePath,
                                 Message = post.Message,
                                 CreationDate = post.CreationDate,
                                 ParentId = post.ParentId,
                                 Type = post.Type,
                                 Name = user.Name,
                                 UserId = user.Id,
                                 ProfileImage = profile.ProfileImage,
                                 Fav = context.Favs.Where(f => f.PostId == post.Id).Select(f => f.UserId).ToArray(),
                                 Comment = context.Posts.Where(c => c.ParentId == post.Id).Count()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
