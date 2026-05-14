using UnityHealth.Models.Request.Auth;

namespace UnityHealth.Services.Auth
{
    public class AuthService : IAuthService
    {
        public Task<string> RegisterToken(RegisterOtpRequest request)
        {
            return Task.FromResult("true");
        }
        public Task<string> Register(RegisterRequest request)
        {
            return Task.FromResult("true");
        }
        public Task<string> Login(LoginRequest request)
        {
            return Task.FromResult("true");
        }
    }
}
