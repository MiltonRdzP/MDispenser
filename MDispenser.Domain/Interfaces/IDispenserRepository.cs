using MDispenser.Domain.Entities;

namespace MDispenser.Domain.Interfaces;

public interface IDispenserRepository
{
    Task<Dispenser?> GetByIdAsync(Guid id);
    Task SaveAsync(Dispenser dispenser);
}
