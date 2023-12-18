using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserProfileDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool UserStatus { get; set; }
        public string? ProfileImage { get; set; }
        public string? BackgroundImage { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int ProfileStatus { get; set; }
    }
}
