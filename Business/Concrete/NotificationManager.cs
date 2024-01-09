using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationManager:INotificationService
    {
        INotificationDal _notificationDal;
        INotificationSettingService _notificationSettingService;

        public NotificationManager(INotificationSettingService notificationSettingService, INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
            _notificationSettingService = notificationSettingService;
        }

        public IResult Add(Notification notification)
        {
           
           var userNotificationSetting = _notificationSettingService.GetUserNotificationSettingById(notification.TargetId).Data;

           var status = CanNotificationBeAdded(userNotificationSetting, notification);


            if(status && notification.TargetId != notification.UserId)
            {
               _notificationDal.Add(notification);
            }
           
            return new SuccessResult();

      
        }

        private bool CanNotificationBeAdded(NotificationSetting notificationSetting,Notification notification)
        {
            if(notificationSetting == null)
            {
                return true;
            }

            if(notification.Type == 1 && notificationSetting.FollowNotification == true)
            {
                return true;
            }
            else if(notification.Type == 2 && notificationSetting.UnfollowNotification == true)
            {
                return true;
            }
            else if(notification.Type == 3 && notificationSetting.FavNotification == true)
            {
                return true;
            }
            else if(notification.Type == 4 && notificationSetting.CommentNotification == true)

            {
                return true;
            }
            else if(notification.Type == 5 && notificationSetting.MessageNotification == true)
            {
                return true;
            }


            return false;

        }

        public IResult Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
            return new SuccessResult();
        }

        public IDataResult<List<UserNotificationDto>> GetAllNotificationByUserId(int id)
        {
            var result = _notificationDal.GetUserNotifications(p => p.TargetId == id && p.IsRead == false).OrderByDescending(p=>p.CreationDate).ToList();
            return new SuccessDataResult<List<UserNotificationDto>>(result);
        }

        public IResult Update(Notification notification)
        {
            _notificationDal.Update(notification);
            return new SuccessResult();
        }

        public IResult UpdateAllReadStateByUserId(int id)
        {
            var result = _notificationDal.GetAll(p => p.TargetId == id && p.IsRead == false);
            if(result.Count > 0)
            {
                foreach (var notification in result)
                {
                    var newEntity = new Notification()
                    {
                        Id = notification.Id,
                        CreationDate = notification.CreationDate,
                        IsRead = true,
                        NotificationIntId = notification.NotificationIntId,
                        NotificationUniqueId = notification.NotificationUniqueId,
                        TargetId = notification.TargetId,
                        Type = notification.Type,
                        UserId = notification.UserId

                    };
                    _notificationDal.Update(newEntity);
                }
            }

            return new SuccessResult();
        }

        public IResult UpdateReadStateByNotificationId(Guid notificationId)
        {
            var result = _notificationDal.Get(p => p.Id == notificationId);

            var newEntity = new Notification()
            {
                Id = result.Id,
                CreationDate = result.CreationDate,
                IsRead = true,
                NotificationIntId = result.NotificationIntId,
                NotificationUniqueId = result.NotificationUniqueId,
                TargetId = result.TargetId,
                Type = result.Type,
                UserId = result.Type
            };
            _notificationDal.Update(newEntity);
            return new SuccessResult();

        }
    }
}
