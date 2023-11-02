using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Profile:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfileImage { get; set; }
        public string BackgroundImage { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
