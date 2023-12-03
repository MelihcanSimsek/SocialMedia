using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserReportDal : EfEntityFrameworkBase<UserReport, SocialMediaContext>, IUserReportDal
    {
        public List<ReportDetailDto> GetAllReportDetail()
        {
            using (var context = new SocialMediaContext())
            {
                var postIds = context.UserReports
                    .GroupBy(userReport => userReport.PostId)
                    .Select(groupedReports => groupedReports.OrderBy(r => r.Id).FirstOrDefault().PostId)
                    .Where(postId => postId != null)
                    .ToList();

                var result = from postId in postIds
                             join post in context.Posts on postId equals post.Id
                             join user in context.Users on post.UserId equals user.Id
                             join profile in context.Profiles on user.Id equals profile.UserId
                             let reportIds = context.UserReports
                                 .Where(ur => ur.PostId == postId)
                                 .Select(ur => ur.ReportId)
                                 .Distinct()
                                 .ToArray()
                             let reasons = context.Reports
                                 .Where(r => reportIds.Contains(r.Id))
                                 .Select(r => r.Reason)
                                 .ToArray()
                             select new ReportDetailDto
                             {
                                 ReportedUserId = user.Id,
                                 ReportedUserName = user.Name,
                                 ReportedUserImage = profile.ProfileImage,
                                 ReportedContentId = post.Id,
                                 ReportedContentCreationDate = post.CreationDate,
                                 ReportedContentMessage = post.Message,
                                 ReportedContentImagePath = post.ImagePath,
                                 ReportReasons = reasons,
                                 ReportedContentType = post.Type
                             };

                return result.ToList();
            }
        }
    }
}
