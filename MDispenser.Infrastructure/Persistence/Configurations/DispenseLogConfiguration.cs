using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class DispenseLogConfiguration : IEntityTypeConfiguration<DispenseLog>
    {
        public void Configure(EntityTypeBuilder<DispenseLog> builder)
        {
            builder.ToTable("dispense_logs");

            builder.Property(dl => dl.Amount)
                .HasColumnType("decimal(10,3)")
                .IsRequired();

            builder.Property(dl => dl.MeasurementUnit)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(dl => dl.TriggerSource)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(dl => dl.Device)
                .WithMany(d => d.DispenseLogs)
                .HasForeignKey(dl => dl.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(dl => dl.TriggeredBy)
                .WithMany()
                .HasForeignKey(dl => dl.TriggeredByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(dl => dl.DeviceId);
            builder.HasIndex(dl => dl.DispensedAt);
        }
    }
}
