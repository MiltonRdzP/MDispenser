using MDispenser.Application.Abstractions;
using MDispenser.Application.DTOs;
using MDispenser.Domain.Entities;
using MDispenser.Domain.Interfaces;

namespace MDispenser.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repository;
        private readonly ITimeProvider _timeProvider;

        public DeviceService(IDeviceRepository repository, ITimeProvider timeProvider)
        {
            _repository = repository;
            _timeProvider = timeProvider;
        }

        public async Task<bool> DispenseFoodAsync(int deviceId)
        {
            var dispenser = await _repository.GetByIdAsync(deviceId);
            if (dispenser == null)
                return false;

            // Update last dispense time
            //dispenser.Dispense(_timeProvider.GetCurrentTime());

            await _repository.SaveAsync(dispenser);
            return true;
        }

        public async Task<DeviceDto?> GetByIdAsync(int deviceId)
        {
            var device = await _repository.GetByIdAsync(deviceId);
            if (device == null)
                return null;

            return new DeviceDto
            {
                DeviceId = device.DeviceId,
                HomeId = device.HomeId,
                DeviceName = device.DeviceName,
                DeviceType = device.DeviceType,
                Manufacturer = device.Manufacturer,
                Model = device.Model,
                SerialNumber = device.SerialNumber,
                IpAddress = device.IpAddress,
                MacAddress = device.MacAddress,
                FirmwareVersion = device.FirmwareVersion,
                IsActive = device.IsActive,
                CreatedAt = device.CreatedAt,
                UpdatedAt = device.UpdatedAt
            };
        }

        public async Task<bool> UpdateDeviceAsync(DeviceDto deviceDto)
        {
            var existing = await _repository.GetByIdAsync(deviceDto.DeviceId);
            if (existing == null)
                return false;

            
            await _repository.SaveAsync(existing);
            return true;
        }

        public async Task<bool> DeleteDeviceAsync(int deviceId)
        {
            var existing = await _repository.GetByIdAsync(deviceId);
            if (existing == null)
                return false;

            return true;
        }

        public async Task<bool> SaveAsync(DeviceDto deviceDto)
        {
            var entity = new Device
                {
                DeviceId = deviceDto.DeviceId,
                HomeId = deviceDto.HomeId,
                DeviceName = deviceDto.DeviceName,
                DeviceType = deviceDto.DeviceType,
                Manufacturer = deviceDto.Manufacturer,
                Model = deviceDto.Model,
                SerialNumber = deviceDto.SerialNumber,
                IpAddress = deviceDto.IpAddress,
                MacAddress = deviceDto.MacAddress,
                FirmwareVersion = deviceDto.FirmwareVersion,
                IsActive = deviceDto.IsActive,
                CreatedAt = DateTime.UtcNow, // Assuming CreatedAt is set to current time
                UpdatedAt = DateTime.UtcNow // Assuming UpdatedAt is set to current time
            };

            await _repository.SaveAsync(entity);
            return true;
        }

        public async Task<IEnumerable<DeviceDto>> GetAllDevicesAsync()
        {
            var devices = await _repository.GetAllAsync();

            return devices.Select(d => new DeviceDto
            {
                DeviceId = d.DeviceId,
                HomeId = d.HomeId,
                DeviceName = d.DeviceName,
                DeviceType = d.DeviceType,
                Manufacturer = d.Manufacturer,
                Model = d.Model,
                SerialNumber = d.SerialNumber,
                IpAddress = d.IpAddress,
                MacAddress = d.MacAddress,
                FirmwareVersion = d.FirmwareVersion,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            });
        }

        public async Task<int> CreateDevice(DeviceDto deviceDto)
        {
            var entity = new Device
            {
                HomeId = deviceDto.HomeId,
                DeviceName = deviceDto.DeviceName,
                DeviceType = deviceDto.DeviceType,
                Manufacturer = deviceDto.Manufacturer,
                Model = deviceDto.Model,
                SerialNumber = deviceDto.SerialNumber,
                IpAddress = deviceDto.IpAddress,
                MacAddress = deviceDto.MacAddress,
                FirmwareVersion = deviceDto.FirmwareVersion,
                IsActive = deviceDto.IsActive,
                CreatedAt = DateTime.UtcNow, // Assuming CreatedAt is set to current time
                UpdatedAt = DateTime.UtcNow // Assuming UpdatedAt is set to current time
            };  

            await _repository.SaveAsync(entity);
            return entity.DeviceId; // Assuming `Id` is `int`, if it's `Guid`, change return type
        }
    }
}
