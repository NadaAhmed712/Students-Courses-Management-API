using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsCourses.BLL.Dto.Auth;
using StudentsCourses.BLL.Services.Abstraction;

namespace StudentsCourses.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (result.IsHaveError)
            {
                return Unauthorized();
            }
            return Ok(result.Result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);
            if (result.IsHaveError)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result.Result);
        }
    }
}
