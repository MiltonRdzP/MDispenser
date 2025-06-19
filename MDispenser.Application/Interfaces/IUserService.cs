using MDispenser.Application.DTOs.User;
using MDispenser.Domain.Common;

namespace MDispenser.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<int>> CreateUserAsync(UserCreateDto userDto);
    }
}
