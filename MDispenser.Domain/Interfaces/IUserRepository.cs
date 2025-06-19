using MDispenser.Domain.Entities;

namespace MDispenser.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByUsernameAsync(string username);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsUsernameUniqueAsync(string username);

    Task InsertAsync(User user);
}
