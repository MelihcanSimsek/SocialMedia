using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Notification:IEntity
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int TargetId { get; set; }
        public int? NotificationIntId { get; set; }
        public Guid? NotificationUniqueId { get; set; }
        public int Type { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
