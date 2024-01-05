using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NotificationSettingManager : INotificationSettingService
    {
        INotificationSettingDal _notificationSettingDal;
        public NotificationSettingManager(INotificationSettingDal notificationSettingDal)
        {
            _notificationSettingDal = notificationSettingDal;
        }
        public IResult Add(NotificationSetting notificationSetting)
        {
            _notificationSettingDal.Add(notificationSetting);
            return new SuccessResult();
        }

        public IResult Delete(NotificationSetting notificationSetting)
        {
            _notificationSettingDal.Delete(notificationSetting);
            return new SuccessResult();
        }

        public IDataResult<NotificationSetting> GetUserNotificationSettingById(int id)
        {
            var result = _notificationSettingDal.Get(p => p.UserId == id);
            return new SuccessDataResult<NotificationSetting>(result);
        }

        public IResult Update(NotificationSetting notificationSetting)
        {
            _notificationSettingDal.Update(notificationSetting);
            return new SuccessResult();
        }
    }
}
