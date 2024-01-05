using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class NotificationSetting:IEntity
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public bool FollowNotification { get; set; }
        public bool UnfollowNotification { get; set; }
        public bool CommentNotification { get; set; }
        public bool FavNotification { get; set; }
        public bool MessageNotification { get; set; }
    }
}
