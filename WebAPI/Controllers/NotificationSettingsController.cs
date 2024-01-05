using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationSettingsController : ControllerBase
    {
        INotificationSettingService _notificationSettingService;
        public NotificationSettingsController(INotificationSettingService notificationSettingService)
        {
            _notificationSettingService = notificationSettingService;
        }

        [HttpPost("add")]
        public IActionResult Add(NotificationSetting notificationSetting)
        {
            var result = _notificationSettingService.Add(notificationSetting);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(NotificationSetting notificationSetting)
        {
            var result = _notificationSettingService.Delete(notificationSetting);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(NotificationSetting notificationSetting)
        {
            var result = _notificationSettingService.Update(notificationSetting);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getnotificationsettingsbyid")]
        public IActionResult GetNotificationSettingsById(int id)
        {
            var result = _notificationSettingService.GetUserNotificationSettingById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
