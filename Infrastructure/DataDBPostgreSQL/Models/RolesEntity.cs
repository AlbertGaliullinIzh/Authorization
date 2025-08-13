using Authorization.Infrastructure.DataDB.Models;

namespace Infrastructure.DataDBPostgreSQL.Models
{
    public class RoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<RatioUserAndRolesEntity> Users { get; set; }
    }
}
