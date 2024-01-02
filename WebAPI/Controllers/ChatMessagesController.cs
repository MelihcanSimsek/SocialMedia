using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessagesController : ControllerBase
    {
        IChatMessageService _chatMessageService;
        public ChatMessagesController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("image"))] IFormFile? file, [FromForm] ChatMessage chatMessage)
        {
            var result = _chatMessageService.Add(file,chatMessage);

            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ChatMessage chatMessage)
        {
            var result = _chatMessageService.Delete(chatMessage);
            if(result.Success)

            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(ChatMessage chatMessage)
        {
            var result = _chatMessageService.Update(chatMessage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallchatmessages")]
        public IActionResult GetAllChatMessages(Guid id)
        {
            var result = _chatMessageService.GetAllMessageDetail(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("updateallmessagesseentime")]
        public IActionResult UpdateAllMessagesSeenTime(ChatUserDto entity)
        {
            var result = _chatMessageService.UpdateAllMessagesSeenTime(entity);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
