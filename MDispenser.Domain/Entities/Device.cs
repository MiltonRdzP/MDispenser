using System.ComponentModel.DataAnnotations.Schema;

namespace MDispenser.Domain.Entities;

public class Device
{
    [Column("device_id")] // Maps to the PostgreSQL column name
    public int DeviceId { get; set; }
    public int HomeId { get; set; }
    public string DeviceName { get; set; } = string.Empty;
    public string DeviceType { get; set; } = string.Empty;
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public string? SerialNumber { get; set; }
    public string? IpAddress { get; set; }
    public string? MacAddress { get; set; }
    public string? FirmwareVersion { get; set; }
    public bool IsActive { get; set; } = true;

    public int DeviceTypeId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Home Home { get; set; } = null!; // Assuming Home is a required relationship
    public ICollection<DeviceEvent> Events { get; set; } = new List<DeviceEvent>();

    public ICollection<DeviceAction> Actions { get; set; } = new List<DeviceAction>();

    // Navigation property for DispenseLogs (if needed)
    public ICollection<DispenseLog> DispenseLogs { get; private set; } = new List<DispenseLog>();
}
