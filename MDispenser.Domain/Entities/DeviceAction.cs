using MDispenser.Domain.Entities;

public class DeviceAction
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public string ActionType { get; set; } // "dispense", "calibrate", "clean"
    public decimal? Amount { get; set; }
    public string Status { get; set; } // "pending", "processing", "completed", "failed"
    public string? ErrorMessage { get; set; }
    public int? TriggeredByUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public Device Device { get; set; }
    public User? TriggeredBy { get; set; }

}