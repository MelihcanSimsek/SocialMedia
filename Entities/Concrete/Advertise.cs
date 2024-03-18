using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Advertise:IEntity
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImagePath { get; set; }
        public int Type { get; set; }
    }
}
