using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ChatResponseDto:IDto
    {
        public Guid? ChatId { get; set; }
        public bool Open { get; set; }
    }
}
