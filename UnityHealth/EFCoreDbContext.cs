using Microsoft.EntityFrameworkCore;
using UnityHealth.Models.Database.Auth;

namespace UnityHealth
{
        public class EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : DbContext(options)
        {
            public DbSet<OtpModel> OtpModel { get; set; }
            public DbSet<UserModel> UserModel { get; set; }
            public DbSet<UserRoleModel> UserRoleModel { get; set; }
        }
}
