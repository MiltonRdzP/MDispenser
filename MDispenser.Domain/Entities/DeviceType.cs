namespace MDispenser.Domain.Entities;

public class DeviceType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MeasurementUnit { get; set; }
    public decimal? MaxCapacity { get; set; }
    public decimal? MinDispenseAmount { get; set; }
    public bool RequiresCalibration { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Device> Devices { get; private set; } = new List<Device>();
}