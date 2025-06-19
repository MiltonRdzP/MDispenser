using MDispenser.Application.Abstractions;
using MDispenser.Application.DTOs;
using MDispenser.Domain.Interfaces;

namespace MDispenser.Application.Services
{
    public class DispenserService : IDispenserService
    {
        private readonly IDispenserRepository _repository;
        private readonly ITimeProvider _timeProvider;

        public DispenserService(IDispenserRepository repository, ITimeProvider timeProvider)
        {
            _repository = repository;
            _timeProvider = timeProvider;
        }

        public async Task<bool> DispenseFoodAsync(Guid dispenserId)
        {
            var dispenser = await _repository.GetByIdAsync(dispenserId);

            if (dispenser == null)
                return false;

            dispenser.Dispense(_timeProvider.GetCurrentTime());
            await _repository.SaveAsync(dispenser);
            return true;
        }

        public async Task<DispenserDto?> GetByIdAsync(Guid dispenserId)
        {
            var dispenser = await _repository.GetByIdAsync(dispenserId);

            if (dispenser == null)
                return null;

            return new DispenserDto
            {
                Id = dispenser.Id,
                Name = dispenser.Name,
                LastDispenseTime = dispenser.LastDispenseTime
            };
        }
    }
}
