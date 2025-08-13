using Infrastructure.DataDBPostgreSQL.Models;

namespace Authorization.Infrastructure.DataDB.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid AuthDataEntityId { get; set; }
        public AuthDataEntity? AuthData { get; set; }
        public RoleEntity Role { get; set; }

    }
}
