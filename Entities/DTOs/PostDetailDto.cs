using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PostDetailDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public string? Name { get; set; }
        public string? ProfileImage { get; set; }
        public int[] Fav { get; set; }
        public int Comment { get; set; }
        public int ParentId { get; set; }
        public string? Message { get; set; }
        public string? ImagePath { get; set; }
        public int Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
