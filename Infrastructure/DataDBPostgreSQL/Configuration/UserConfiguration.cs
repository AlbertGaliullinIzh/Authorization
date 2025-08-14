using Authorization.Infrastructure.DataDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorization.Infrastructure.DataDB.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                 .IsRequired()
                 .HasMaxLength(255);
            builder.HasOne(u => u.AuthData)
                .WithOne(a => a.User)
                .HasForeignKey<UserEntity>(u => u.AuthDataEntityId);
            builder.HasOne(u => u.Role)
               .WithMany(r => r.Users) 
               .HasForeignKey(u => u.RoleEntityId)
               .IsRequired();
        }
    }
}
