using MDispenser.Application.DTOs;

namespace MDispenser.Application.Abstractions
{
    public interface IDeviceService
    {
        Task<bool> DispenseFoodAsync(int deviceId);
        Task<DeviceDto?> GetByIdAsync(int deviceId);

        Task<bool> UpdateDeviceAsync(DeviceDto deviceDto);

        Task<bool> DeleteDeviceAsync(int deviceId);

        Task<bool> SaveAsync(DeviceDto deviceDto);

        Task<IEnumerable<DeviceDto>> GetAllDevicesAsync();

        Task<int> CreateDevice(DeviceDto deviceDto);

    }
}
