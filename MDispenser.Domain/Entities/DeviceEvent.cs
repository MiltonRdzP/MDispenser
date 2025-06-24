namespace MDispenser.Domain.Entities;
public class DeviceEvent
{
    public int EventId { get; private set; }
    public int DeviceId { get; private set; }
    public string EventType { get; private set; }
    public string? EventData { get; private set; } // Could use System.Text.Json for JSON handling
    public DateTime EventTimestamp { get; private set; } = DateTime.UtcNow;

    // Navigation property
    public Device Device { get; private set; }

    public DeviceEvent(int deviceId, string eventType, string? eventData = null)
    {
        DeviceId = deviceId;
        EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
        EventData = eventData;
    }
}