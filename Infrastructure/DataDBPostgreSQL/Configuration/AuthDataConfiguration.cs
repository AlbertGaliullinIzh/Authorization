using Authorization.Infrastructure.DataDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorization.Infrastructure.DataDB.Configuration
{
    public class AuthDataConfiguration : IEntityTypeConfiguration<AuthDataEntity>
    {
        public void Configure(EntityTypeBuilder<AuthDataEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Password)
                .IsRequired();
        }
    }
}
