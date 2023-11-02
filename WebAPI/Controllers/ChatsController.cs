using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        IChatService _chatService;
        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("add")]
        public IActionResult Add(Chat chat)
        {
            var result = _chatService.Add(chat);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Chat chat)
        {
            var result = _chatService.Delete(chat);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Chat chat)
        {
            var result = _chatService.Update(chat);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallchatmessagesbyusersid")]
        public IActionResult GetAllChatMessagesByUsersId(int firstid,int secondid)
        {
            var result = _chatService.GetAllChatMessagesByUsersId(firstid, secondid);
            if(result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
