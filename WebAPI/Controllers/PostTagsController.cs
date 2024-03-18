using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTagsController : ControllerBase
    {
        IPostTagService _postTagService;
        public PostTagsController(IPostTagService postTagService)
        {
            _postTagService = postTagService;
        }

        [HttpPost("add")]
        public IActionResult Add(PostTag postTag)
        {
            var result = _postTagService.Add(postTag);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
