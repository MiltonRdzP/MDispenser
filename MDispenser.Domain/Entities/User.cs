namespace MDispenser.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastModifiedAt { get; set; }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public ICollection<UserHomeAccess> HomeAccesses { get; private set; } = new List<UserHomeAccess>();
    public ICollection<DeviceEvent> DeviceEvents { get; private set; } = new List<DeviceEvent>();

    public User(string username, string email, string passwordHash)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
    }

}