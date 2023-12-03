using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReportsController : ControllerBase
    {
        IUserReportService _userReportService;
        public UserReportsController(IUserReportService userReportService)
        {
            _userReportService = userReportService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserReport userReport)
        {
            var result =  _userReportService.Add(userReport);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(UserReport userReport)
        {
            var result = _userReportService.Delete(userReport);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userReportService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
