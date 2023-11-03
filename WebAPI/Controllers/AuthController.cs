using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var userCheck = _authService.UserExists(registerDto.Email);
            if(!userCheck.Success)
            {
                return BadRequest(userCheck);
            }

            var result = _authService.Register(registerDto).Data;
            var token = _authService.CreateAccessToken(result);
            if(token.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var userCheck = _authService.Login(loginDto);
            if(!userCheck.Success)
            {
                return BadRequest(userCheck);
            }
            var token = _authService.CreateAccessToken(userCheck.Data);
            if(token.Success)
            {
                return Ok(token);
            }
            return BadRequest(token);
        }
    }
}
