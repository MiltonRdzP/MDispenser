using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(r => r.RoleId);

            builder.Property(r => r.RoleName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasColumnType("text");

            builder.Property(r => r.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Index
            builder.HasIndex(r => r.RoleName)
                .IsUnique();
        }
    }
}
