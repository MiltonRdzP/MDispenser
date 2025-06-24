using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("devices");

            // Correct key configuration - remove HasName() for the key
            builder.HasKey(d => d.DeviceId);

            // Explicit column mapping for DeviceId
            builder.Property(d => d.DeviceId)
                .HasColumnName("device_id")  // Maps to the PostgreSQL column
                .ValueGeneratedOnAdd();     // For serial/identity column

            builder.Property(d => d.HomeId)
                .HasColumnName("home_id")
                .IsRequired();

            // Other property configurations
            builder.Property(d => d.DeviceName)
                .HasColumnName("device_name")  // Explicit column name
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.DeviceType)
                .HasColumnName("device_type")  // Explicit column name
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Manufacturer)
                .HasColumnName("manufacturer")
                .HasMaxLength(100);

            builder.Property(d => d.Model)
                .HasColumnName("model")
                .HasMaxLength(100);

            builder.Property(d => d.SerialNumber)
                .HasColumnName("serial_number")
                .HasMaxLength(100);

            builder.Property(d => d.IpAddress)
                .HasColumnName("ip_address")
                .HasMaxLength(45);

            builder.Property(d => d.MacAddress)
                .HasColumnName("mac_address")
                .HasMaxLength(17);

            builder.Property(d => d.FirmwareVersion)
                .HasColumnName("firmware_version")
                .HasMaxLength(50);

            builder.Property(d => d.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(d => d.UpdatedAt)
                .HasColumnName("updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(d => d.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            // DeviceType relationship
            builder.Property(d => d.DeviceTypeId)
                .HasColumnName("device_type_id")
                .IsRequired();

            builder.Property(d => d.DeviceType)
               .HasColumnName("device_type")
               .IsRequired();

           
            // Home relationship
            builder.HasOne(d => d.Home)
                .WithMany(h => h.Devices)
                .HasForeignKey(d => d.HomeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}