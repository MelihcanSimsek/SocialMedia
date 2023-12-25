using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entities.Concrete
{
    public class UserChat:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid ChatId { get; set; }
    }
}
