using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserTag:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Label { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
