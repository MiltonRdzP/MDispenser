using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations;

public class DeviceTypeConfiguration : IEntityTypeConfiguration<DeviceType>
{
    public void Configure(EntityTypeBuilder<DeviceType> builder)
    {
        builder.ToTable("device_types");

        builder.Property(dt => dt.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(dt => dt.MeasurementUnit)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(dt => dt.MaxCapacity)
            .HasColumnType("decimal(10,3)");

        builder.Property(dt => dt.MinDispenseAmount)
            .HasColumnType("decimal(10,3)");

        builder.HasIndex(dt => dt.Name)
            .IsUnique();
    }
}
