using UnityHealth.Models.Enums;

namespace UnityHealth.Models.Database.Auth
{
    public class UserRoleModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserModel User { get; set; }

        public UserRoleType Role { get; set; }
    }
}