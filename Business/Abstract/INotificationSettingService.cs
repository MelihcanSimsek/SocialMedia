using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationSettingService
    {
        IResult Add(NotificationSetting notificationSetting);
        IResult Delete(NotificationSetting notificationSetting);
        IResult Update(NotificationSetting notificationSetting);
        IDataResult<NotificationSetting> GetUserNotificationSettingById(int id);
    }
}
