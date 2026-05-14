using Microsoft.AspNetCore.Mvc;
using UnityHealth.Models.Request.Auth;
using UnityHealth.Services.Auth;

namespace UnityHealth.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
       private readonly IAuthService _authService;
       public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register-otp")]
        public async Task<IActionResult> Register([FromBody] RegisterOtpRequest req)
        {
            var otp = await _authService.RegisterToken(req);
            return Ok(new { otp });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var token = await _authService.Register(req);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var token = await _authService.Login(req);
            return Ok(new { token });
        }
    }
}
