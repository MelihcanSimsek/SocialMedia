using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserBanDto:IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? BanDate { get; set; }
        public bool Status { get; set; }
    }
}
