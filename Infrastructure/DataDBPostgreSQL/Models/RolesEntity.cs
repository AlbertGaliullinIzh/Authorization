using Authorization.Infrastructure.DataDB.Models;

namespace Infrastructure.DataDBPostgreSQL.Models
{
    public class RoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

    }
}
