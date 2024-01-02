using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MessageDto:IDto
    {
        public Guid MessageId { get; set; }
        public Guid ChatId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public int Type { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? SeenAt { get; set; }
    }
}
