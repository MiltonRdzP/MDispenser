using MDispenser.Domain.Entities;

public class DispenseLog
{
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public decimal Amount { get; private set; }
    public string MeasurementUnit { get; private set; }
    public int? TriggeredByUserId { get; private set; }
    public string TriggerSource { get; private set; } // "manual", "schedule", "api", "system"
    public DateTime DispensedAt { get; private set; } = DateTime.UtcNow;
    public string? Notes { get; private set; }

    public Device Device { get; private set; }
    public User? TriggeredBy { get; private set; }

    public DispenseLog(int deviceId, decimal amount, string measurementUnit,
                      string triggerSource, int? triggeredByUserId = null)
    {
        DeviceId = deviceId;
        Amount = amount;
        MeasurementUnit = measurementUnit ?? throw new ArgumentNullException(nameof(measurementUnit));
        TriggerSource = triggerSource ?? throw new ArgumentNullException(nameof(triggerSource));
        TriggeredByUserId = triggeredByUserId;
    }
}