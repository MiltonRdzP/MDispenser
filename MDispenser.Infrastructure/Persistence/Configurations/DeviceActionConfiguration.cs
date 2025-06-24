using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MDispenser.Infrastructure.Persistence.Configurations
{
    public class DeviceActionConfiguration : IEntityTypeConfiguration<DeviceAction>
    {
        public void Configure(EntityTypeBuilder<DeviceAction> builder)
        {
            builder.ToTable("device_actions");

            builder.Property(da => da.ActionType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(da => da.Amount)
                .HasColumnType("decimal(10,3)");

            builder.Property(da => da.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending");

            builder.HasOne(da => da.Device)
                .WithMany(d => d.Actions)
                .HasForeignKey(da => da.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(da => da.TriggeredBy)
                .WithMany()
                .HasForeignKey(da => da.TriggeredByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(da => da.DeviceId);
            builder.HasIndex(da => da.Status);
            builder.HasIndex(da => da.CreatedAt);
        }
    }

}
