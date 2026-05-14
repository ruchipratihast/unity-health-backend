using UnityHealth.Models.Request.Auth;

namespace UnityHealth.Services.Auth
{
    public interface IAuthService
    {
        public Task<string> RegisterToken(RegisterOtpRequest request);
        public Task<string> Register(RegisterRequest request);
        public Task<string> Login(LoginRequest request);
    }
}
