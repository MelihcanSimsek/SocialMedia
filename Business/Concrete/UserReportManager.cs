using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserReportManager : IUserReportService
    {
        IUserReportDal _userReportDal;
        IPostService _postService;
        public UserReportManager(IUserReportDal userReportDal, IPostService postService)
        {
            _userReportDal = userReportDal;
            _postService = postService;
        }
        public IResult Add(UserReport userReport)
        {
            var result = _userReportDal.Get(ur => ur.UserId == userReport.UserId && ur.PostId == userReport.PostId && ur.ReportId == userReport.ReportId);
            if(result != null)
            {
                return new ErrorResult(Messages.UserAlreadyReported);
            }
            _userReportDal.Add(userReport);
            return new SuccessResult();
        }

        public IResult Delete(UserReport userReport)
        {
            var reports = _userReportDal.GetAll(u => u.PostId == userReport.Id);
            foreach (var report in reports)
            {
                _userReportDal.Delete(report);
            }
            
            return new SuccessResult();
        }

        public IResult DeleteAllUserReportByUserId(int id)
        {
            var posts = _postService.GetAllPostDetailByUserId(id).Data;
            foreach (var post in posts)
            {
               var results =  _userReportDal.GetAll(ur => ur.PostId == post.Id);
                if(results != null)
                {
                    foreach (var result in results)
                    {
                        _userReportDal.Delete(result);
                    }
                    
                }
            }


            return new SuccessResult();
        }

        public IDataResult<List<ReportDetailDto>> GetAll()
        {
            var result = _userReportDal.GetAllReportDetail();
            return new SuccessDataResult<List<ReportDetailDto>>(result);
        }
    }
}
