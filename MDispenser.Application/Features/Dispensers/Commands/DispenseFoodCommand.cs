using MDispenser.Domain.Common;
using MediatR;

namespace MDispenser.Application.Features.Dispensers.Commands
{
    public record DispenseFoodCommand(Guid DispenserId) : IRequest<Result>;
}
