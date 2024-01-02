using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ChatProfileDto:IDto
    {
        public int UserId { get; set; }
        public Guid ChatId { get; set; }
        public string Name { get; set; }
        public string? ProfileImage { get; set; }
        public string? LastMessage { get; set; }
        public int? LastMessageType { get; set; }
        public DateTime? LastMessageDate { get; set; }
        public int NotShowedMessagesCount { get; set; }
    }
}
