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
    public class NotificationManager:INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public IResult Add(Notification notification)
        {
            _notificationDal.Add(notification);
            return new SuccessResult();
        }

        public IResult Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
            return new SuccessResult();
        }

        public IDataResult<List<Notification>> GetAllNotificationByUserId(int id)
        {
            var result = _notificationDal.GetAll(n => n.UserId == id);
            return new SuccessDataResult<List<Notification>>(result);
        }

        public IResult Update(Notification notification)
        {
            _notificationDal.Update(notification);
            return new SuccessResult();
        }
    }
}
