using MDispenser.Domain.Entities;
using MDispenser.Domain.Interfaces;
using MDispenser.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MDispenser.Infrastructure.Persistence
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Device?> GetByIdAsync(int id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task SaveAsync(Device device)
        {
            if (device.DeviceId == 0) // Assuming new devices have Id = 0
            {
                await _context.Devices.AddAsync(device);
            }
            else
            {
                _context.Devices.Update(device);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var device = await GetByIdAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }
    }
}
