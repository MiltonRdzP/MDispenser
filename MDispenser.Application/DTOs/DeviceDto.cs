namespace MDispenser.Application.DTOs
{
    public class DeviceDto
    {
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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
