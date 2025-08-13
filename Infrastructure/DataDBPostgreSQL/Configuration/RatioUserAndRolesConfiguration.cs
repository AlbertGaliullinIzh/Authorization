using Infrastructure.DataDBPostgreSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorization.Infrastructure.DataDB.Configuration
{
    public class RatioUserAndRolesConfiguration : IEntityTypeConfiguration<RatioUserAndRolesEntity>
    {
        public void Configure(EntityTypeBuilder<RatioUserAndRolesEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(u => u.RoleId);
        }
    }

}
