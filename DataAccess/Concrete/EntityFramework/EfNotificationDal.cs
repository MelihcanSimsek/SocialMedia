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
    public class EfNotificationDal : EfEntityFrameworkBase<Notification, SocialMediaContext>, INotificationDal
    {
        public List<UserNotificationDto> GetUserNotifications(Expression<Func<UserNotificationDto, bool>> filter = null)
        {
            using (var context = new SocialMediaContext())
            {
                var result = from user in context.Users
                             join notification in context.Notifications
                             on user.Id equals notification.UserId
                             select new UserNotificationDto
                             {
                                 Id = notification.Id,
                                 CreationDate = notification.CreationDate,
                                 TargetId = notification.TargetId,
                                 UserId = user.Id,
                                 IsRead = notification.IsRead,
                                 UserName = user.Name,
                                 Type = notification.Type,
                                 NotificationIntId = notification.NotificationIntId,
                                 NotificationUniqueId = notification.NotificationUniqueId

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        /*
         Type
         Takip Etti 1 int
         Takipten Çıktı 2 int
         Gönderi Beğendi 3 int,
         Yorum yaptı 4 int
         Mesaj gönderdi 5 Guid
         */
    }
}
