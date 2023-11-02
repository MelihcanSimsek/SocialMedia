using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        INotificationService _notificationService;
        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("add")]
        public IActionResult Add(Notification notification)
        {
            var result = _notificationService.Add(notification);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Notification notification)
        {
            var result = _notificationService.Delete(notification);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Notification notification)
        {
            var result = _notificationService.Update(notification);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallnotificationbyuserid")]
        public IActionResult GetAllNotificationByUserId(int id)
        {
            var result = _notificationService.GetAllNotificationByUserId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
