using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavsController : ControllerBase
    {
        IFavService _favService;
        public FavsController(IFavService favService)
        {
            _favService = favService;
        }

        [HttpPost("add")]
        public IActionResult Add(Fav fav)
        {
            var result = _favService.Add(fav);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Fav fav)
        {
            var result = _favService.Delete(fav);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Fav fav)
        {
            var result = _favService.Update(fav);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
           
        }

        [HttpGet("getpostfavnumber")]
        public IActionResult GetPostFavNumber(int id)
        {
            var result = _favService.GetPostFavNumber(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        

    }
}
