using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatsController : ControllerBase
    {
        IUserChatService _userChatService;
        public UserChatsController(IUserChatService userChatService)
        {
            _userChatService = userChatService;
        }

        [HttpPost("add")]

        public IActionResult Add(UserChat userChat)
        {
            var result = _userChatService.Add(userChat);
            if(result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserChat userChat)
        {
            var result = _userChatService.Delete(userChat);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserChat userChat)

        {
            var result = _userChatService.Update(userChat);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("checkusershaveachatroom")]
        public IActionResult CheckUsersHaveaChatRoom(int firstid,int secondid)
        {
            var result = _userChatService.CheckUsersHaveaChatRoom(firstid, secondid);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getusermessagelist")]
        public IActionResult GetUserMessageList(int id)
        {
            var result = _userChatService.GetUserMessageList(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
