using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        IResult Add(Notification notification);
        IResult Delete(Notification notification);
        IResult Update(Notification notification);
        IDataResult<List<UserNotificationDto>> GetAllNotificationByUserId(int id);
        IResult UpdateReadStateByNotificationId(Guid notificationId);
        IResult UpdateAllReadStateByUserId(int id);
    }
}
