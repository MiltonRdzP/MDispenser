using MDispenser.Domain.Entities;
using MDispenser.Domain.Interfaces;
using MDispenser.Infrastructure.Persistence.Configurations;

namespace MDispenser.Infrastructure.Persistence
{
    public class DispenserRepository : IDispenserRepository
    {
        private readonly ApplicationDbContext _context;

        public DispenserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dispenser?> GetByIdAsync(Guid id)
        {
            return await _context.Dispensers.FindAsync(id);
        }

        public async Task SaveAsync(Dispenser dispenser)
        {
            _context.Dispensers.Update(dispenser);
            await _context.SaveChangesAsync();
        }
    }
}
