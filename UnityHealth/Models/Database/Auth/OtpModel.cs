namespace UnityHealth.Models.Database.Auth
{
    public class OtpModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Otp { get; set; } = string.Empty;

        public DateTime Expiry { get; set; }

        public bool IsUsed { get; set; } = false;
    }
}