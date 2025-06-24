using MDispenser.Domain.Entities;

namespace MDispenser.Domain.Interfaces;

public interface IDeviceRepository
{
    Task<Device?> GetByIdAsync(int id);
    Task SaveAsync(Device device);

    Task<IEnumerable<Device>> GetAllAsync();
    Task DeleteAsync(int id);
    Task UpdateAsync(Device device);  // Often useful to have an explicit update method
}
