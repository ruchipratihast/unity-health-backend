using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;   
using System.Text;
using UnityHealth.Models.Database.Auth;
using UnityHealth.Models.Request.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace UnityHealth.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly EFCoreDbContext _db;
        public AuthService(EFCoreDbContext db) => _db = db;

        private readonly IConfiguration _config;
        public AuthService(EFCoreDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public async Task<string> RegisterOtp(RegisterOtpRequest request)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            var otpModel = new Models.Database.Auth.OtpModel
            {
                Email = request.Email,
                Otp = otp,
                Expiry = DateTime.UtcNow.AddMinutes(5),
            };
            _db.OtpModel.Add(otpModel);
            await _db.SaveChangesAsync();
            return otp;
        }
        public async Task<(bool Success, string Message)> Register(RegisterRequest request)
        {
            var validOtp = _db.OtpModel.AnyAsync(o => o.Email == request.Email && o.Otp == request.Otp && o.Expiry > DateTime.UtcNow);
            if (!validOtp.Result)
            {
                return (false, "Invalid or expired OTP");
            }

            var user = new Models.Database.Auth.UserModel
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            _db.UserModel.Add(user);
            await _db.SaveChangesAsync();
            return (true, "User registered successfully");
        }
        public async Task<(bool Success, string Token)> Login(LoginRequest request)
        {
            var user = await _db.UserModel
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return (false, "Invalid credentials");
            }

            // Generate JWT Token
            var token = CreateJwtToken(user);

            return (true, token);
        }

        private string CreateJwtToken(UserModel user)
        {
            // Access key from appsettings
            var secretKey = _config["JwtSettings:SecretKey"];

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.FullName)
    };

            var token = new JwtSecurityToken(
                issuer: "StudentMgmtAPI",
                audience: "StudentMgmtAPI",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
