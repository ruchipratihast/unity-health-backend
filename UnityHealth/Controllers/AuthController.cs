using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> RegisterOtp([FromBody] RegisterOtpRequest req)
        {
            var otp = await _authService.RegisterOtp(req);
            return Ok(new { otp });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var result = await _authService.Register(req);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var result = await _authService.Login(req);
            if (!result.Success)
            {
                return Unauthorized(new { message = result.Token }); // Here result.Token contains the error message
            }

            // Return only the token
            return Ok(new { token = result.Token });
        }
    }
}
