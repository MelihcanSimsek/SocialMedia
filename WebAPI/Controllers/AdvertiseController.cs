using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertiseController : ControllerBase
    {
        IAdvertiseService _advertiseService;
        public AdvertiseController(IAdvertiseService advertiseService)
        {
            _advertiseService = advertiseService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("image"))] IFormFile? file, [FromForm] Advertise advertise)
        {
            var result = _advertiseService.Add(file,advertise);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getsideadvertise")]
        public IActionResult GetSideAdvertise(int id)
        {
            var result = _advertiseService.GetUserSideAdvertiseByUserId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getmainadvertise")]
        public IActionResult GetMainAdvertise(int id)
        {
            var result = _advertiseService.GetUserMainAdvertiseByUserId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
