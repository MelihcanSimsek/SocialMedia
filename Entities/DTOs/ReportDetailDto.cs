using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ReportDetailDto:IDto
    {
        public int ReportedContentId { get; set; }
        public string? ReportedContentMessage { get; set; }
        public string? ReportedContentImagePath { get; set; }
        public DateTime ReportedContentCreationDate { get; set; }
        public int ReportedUserId { get; set; }
        public string? ReportedUserName { get; set; }
        public string? ReportedUserImage { get; set; }
        public string[] ReportReasons { get; set; }
        public int ReportedContentType { get; set; }


    }
}
