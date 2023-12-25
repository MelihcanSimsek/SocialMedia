using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowersController : ControllerBase
    {
        IFollowerService _followerService;
        public FollowersController(IFollowerService followerService)
        {
            _followerService = followerService;
        }

        [HttpPost("add")]
        public IActionResult Add(Follower follower)
        {
            var result = _followerService.Add(follower);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Follower follower)
        {
            var result = _followerService.Delete(follower);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Follower follower)
        {
            var result = _followerService.Update(follower);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet("getallfollowerbyuserid")]
        public IActionResult GetAllFollowerByUserId(int id)
        {
            var result = _followerService.GetAllFollowerByUserId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallfolloweduseridbyuserid")]
        public IActionResult GetAllFollowedUserIdByUserId(int id)
        {
            var result = _followerService.GetAllFollowedUseridByUserId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getalluserfriends")]
        public IActionResult GetAllUserFriends(int id)
        {
            var result = _followerService.GetAllUserFriends(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalluserfollowerlistwithoutfriends")]
        public IActionResult GetAllUserFollowerListWithoutFriends(int id)
        {
            var result = _followerService.GetAllUserFollowerListWithoutFriends(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalluserfollowedlistwithoutfriends")]
        public IActionResult GetAllUserFollowedListWithoutFriends(int id)
        {
            var result = _followerService.GetAllUserFollowedListWithoutFriends(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
