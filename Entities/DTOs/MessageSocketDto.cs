using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MessageSocketDto
    {
        public Guid ChatId { get; set; }
        public int UserId { get; set; }
    }
}
