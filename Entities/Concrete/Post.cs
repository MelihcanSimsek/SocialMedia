
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ParentId { get; set; }
        public string Message { get; set; }
        public string ImagePath { get; set; }
        public int Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
