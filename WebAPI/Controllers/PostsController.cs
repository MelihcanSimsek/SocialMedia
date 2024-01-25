using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("image"))] IFormFile? file, [FromForm] Post post)
        {
            var result = _postService.Add(file, post);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Post post)
        {
            var result = _postService.Delete(post);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Post post)
        {

            var result = _postService.Update(post);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallpostdetail")]
        public IActionResult GetAllPostDetail(int id)
        {
            var result = _postService.GetAllPostDetail(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpostdetailbyid")]
        public IActionResult GetPostDetailById(int id)
        {
            var result = _postService.GetPostDetailById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcommentbypostid")]
        public IActionResult GetAllCommentByPostId(int id,int userId)
        {
            var result = _postService.GetAllCommentByPostId(id,userId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _postService.GetAll();
            if(result.Success)

            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getpostbyid")]
        public IActionResult GetPostById(int id)
        {
            var result = _postService.GetPostById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       

        [HttpGet("getalluserpost")]
        public IActionResult GetAllUserPost(int id)
        {
            var result = _postService.GetAllUserPost(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallusercomment")]
        public IActionResult GetAllUserComment(int id)
        {

            var result = _postService.GetAllUserComment(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallfavedpostuserid")]
        public IActionResult GetAllFavedPostUserId(int id)
        {
            var result = _postService.GetAllFavedPostUserId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
