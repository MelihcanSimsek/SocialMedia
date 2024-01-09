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

        [HttpGet("getuserfavedposts")]
        public IActionResult GetUserFavedPosts(int id)
        {
            var result = _favService.GetUserFavedPosts(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpostcommentsfav")]
        public IActionResult GetPostCommentsFav(int userId,int postId)
        {
            var result = _favService.GetPostCommentsFav(userId, postId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserpostsfavs")]
        public IActionResult GetUserPostsFavs(int userId,int targetId)
        {
            var result = _favService.GetUserPostsFavs(userId, targetId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserfavpostsfavs")]
        public IActionResult GetUserFavPostsFavs(int userId,int targetId)
        {
            var result = _favService.GetUserFavPostsFavs(userId, targetId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getusercommentsfavs")]
        public IActionResult GetUserCommentsFavs(int userId,int targetId)
        {
            var result = _favService.GetUserCommentsFavs(userId, targetId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





    }
}
