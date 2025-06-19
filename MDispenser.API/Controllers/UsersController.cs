using MDispenser.Application.DTOs.User;
using MDispenser.Application.Interfaces;
using MDispenser.Domain.Common;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDto user)
    {
        var result = await _userService.CreateUserAsync(user);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(new { userId = result.Value });
    }

    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
