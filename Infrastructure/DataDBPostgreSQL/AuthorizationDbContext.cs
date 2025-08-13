using Authorization.Infrastructure.DataDB.Configuration;
using Authorization.Infrastructure.DataDB.Models;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Infrastructure.DataDB
{
    public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AuthDataEntity> AuthData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AuthDataConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
