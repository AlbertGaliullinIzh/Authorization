using Authorization.Infrastructure.DataDB.Models;

namespace Infrastructure.DataDBPostgreSQL.Models
{
    public class RatioUserAndRolesEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
