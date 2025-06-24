using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class HomeConfiguration : IEntityTypeConfiguration<Home>
    {
        public void Configure(EntityTypeBuilder<Home> builder)
        {
            builder.ToTable("homes");

            builder.HasKey(h => h.HomeId);

            builder.Property(h => h.HomeName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(h => h.Address)
                .HasColumnType("text");

            builder.Property(h => h.City)
                .HasMaxLength(100);

            builder.Property(h => h.State)
                .HasMaxLength(100);

            builder.Property(h => h.Country)
                .HasMaxLength(100);

            builder.Property(h => h.PostalCode)
                .HasMaxLength(20);

            builder.Property(h => h.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(h => h.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(h => h.IsActive)
                .HasDefaultValue(true);
        }
    }
}
