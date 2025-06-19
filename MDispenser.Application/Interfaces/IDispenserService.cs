using MDispenser.Application.DTOs;

namespace MDispenser.Application.Abstractions
{
    public interface IDispenserService
    {
        Task<bool> DispenseFoodAsync(Guid dispenserId);
        Task<DispenserDto?> GetByIdAsync(Guid dispenserId);
    }
}
