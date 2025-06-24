using MDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class DeviceEventConfiguration : IEntityTypeConfiguration<DeviceEvent>
    {
        public void Configure(EntityTypeBuilder<DeviceEvent> builder)
        {
            builder.ToTable("device_events");

            builder.HasKey(de => de.EventId);

            builder.Property(de => de.EventType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(de => de.EventData)
                .HasColumnType("jsonb");

            builder.Property(de => de.EventTimestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Relationship
            builder.HasOne(de => de.Device)
                .WithMany(d => d.Events)
                .HasForeignKey(de => de.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(de => de.DeviceId);
            builder.HasIndex(de => de.EventTimestamp);
        }
    }
}
