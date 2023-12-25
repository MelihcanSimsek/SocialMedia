using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ChatMessage:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid ChatId { get; set; }
        public int Type { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
