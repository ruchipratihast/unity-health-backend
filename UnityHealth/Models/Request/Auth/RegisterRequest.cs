using UnityHealth.Models.Enums;

namespace UnityHealth.Models.Request.Auth
{
    public class RegisterRequest
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Otp { get; set; } = string.Empty;

        public UserRoleType Role { get; set; }
    }
}
