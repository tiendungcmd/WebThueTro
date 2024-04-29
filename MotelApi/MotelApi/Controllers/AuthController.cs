using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotelApi.Models;
using MotelApi.Request;
using MotelApi.Services.IServices;

namespace MotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            await _userService.Create(user);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login([FromBody] UserLogin request)
        {
            var result = _userService.Login(request.UserName,request.Password);
            return Ok(result);
        }
    }
}
