public class DispenseLogs
{
    public Guid Id { get; set; }
    public Guid DeviceId { get; set; }
    public DateTime DispensedAt { get; set; }
    public Guid TriggeredBy { get; set; }
}