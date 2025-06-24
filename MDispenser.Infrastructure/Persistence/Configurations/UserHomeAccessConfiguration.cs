using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class UserHomeAccessConfiguration : IEntityTypeConfiguration<UserHomeAccess>
    {
        public void Configure(EntityTypeBuilder<UserHomeAccess> builder)
        {
            builder.ToTable("user_home_access");

            builder.HasKey(uha => uha.AccessId);

            builder.Property(uha => uha.GrantedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relationships
            builder.HasOne(uha => uha.User)
                .WithMany(u => u.HomeAccesses)
                .HasForeignKey(uha => uha.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uha => uha.Home)
                .WithMany(h => h.UserAccesses)
                .HasForeignKey(uha => uha.HomeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uha => uha.Role)
                .WithMany(r => r.UserHomeAccesses)
                .HasForeignKey(uha => uha.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uha => uha.GrantedBy)
                .WithMany()
                .HasForeignKey(uha => uha.GrantedById)
                .OnDelete(DeleteBehavior.SetNull);

            // Composite unique constraint
            builder.HasIndex(uha => new { uha.UserId, uha.HomeId })
                .IsUnique();
        }
    }
}
