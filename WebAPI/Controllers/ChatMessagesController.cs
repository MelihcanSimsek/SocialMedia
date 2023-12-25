using Business.Abstract;
using Entities.Concrete;
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
        public IActionResult Add(ChatMessage chatMessage)
        {
            var result = _chatMessageService.Add(chatMessage);

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

    }
}
