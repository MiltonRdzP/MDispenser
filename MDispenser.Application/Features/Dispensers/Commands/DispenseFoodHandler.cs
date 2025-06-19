using MDispenser.Domain.Interfaces;
using MDispenser.Domain.Common;
using MediatR;

namespace MDispenser.Application.Features.Dispensers.Commands
{
    public class DispenseFoodHandler : IRequestHandler<DispenseFoodCommand, Result>
    {
        private readonly IDispenserRepository _repo;
        private readonly ITimeProvider _time;

        public DispenseFoodHandler(IDispenserRepository repo, ITimeProvider time)
        {
            _repo = repo;
            _time = time;
        }

        public async Task<Result> Handle(DispenseFoodCommand request, CancellationToken ct)
        {
            var dispenser = await _repo.GetByIdAsync(request.DispenserId);
            if (dispenser is null)
                return Result.Failure("Dispenser not found.");

            dispenser.Dispense(_time.GetCurrentTime());

            await _repo.SaveAsync(dispenser);
            return Result.Success();
        }
    }
}
