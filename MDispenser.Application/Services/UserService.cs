using MDispenser.Application.DTOs.User;
using MDispenser.Application.Interfaces;
using MDispenser.Domain.Common;
using MDispenser.Domain.Entities;
using MDispenser.Domain.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<int>> CreateUserAsync(UserCreateDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Email))
            return Result.Failure<int>("Email is required");

        if (string.IsNullOrWhiteSpace(userDto.Password))
            return Result.Failure<int>("Password is required");

        var normalizedEmail = userDto.Email.Trim().ToLower();

        if (await _userRepository.GetByEmailAsync(normalizedEmail) is not null)
            return Result.Failure<int>("User with this email already exists");

        var user = new User(normalizedEmail, userDto.Password) // Use raw password if you’re not hashing
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.UserName
        };

        await _userRepository.InsertAsync(user);

        return Result.Success(user.Id);
    }

    // Additional methods would go here...
}