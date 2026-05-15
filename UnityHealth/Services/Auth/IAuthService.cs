using UnityHealth.Models.Request.Auth;

namespace UnityHealth.Services.Auth
{
    public interface IAuthService
    {
        public Task<string> RegisterOtp(RegisterOtpRequest request);
        public Task<(bool Success, string Message)> Register(RegisterRequest request);
        public Task<(bool Success, string Token)> Login(LoginRequest request);
    }
}
