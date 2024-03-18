using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTagsController : ControllerBase
    {
        IUserTagService _userTagService;
        public UserTagsController(IUserTagService userTagService)
        {
            _userTagService = userTagService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserTag userTag)
        {
            var checkUserTag = _userTagService.CheckUserAlreadyHasAPostLabel(userTag);

            if(!checkUserTag.Success)
            {
                return Ok(checkUserTag);
            }

            var result = _userTagService.Add(userTag);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
