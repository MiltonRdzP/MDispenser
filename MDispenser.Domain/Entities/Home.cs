namespace MDispenser.Domain.Entities;
public class Home
{
    public int HomeId { get; private set; }
    public string HomeName { get; private set; }
    public string? Address { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? Country { get; private set; }
    public string? PostalCode { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;

    // Navigation properties
    public ICollection<UserHomeAccess> UserAccesses { get; private set; } = new List<UserHomeAccess>();
    public ICollection<Device> Devices { get; private set; } = new List<Device>();

    public Home(string homeName)
    {
        HomeName = homeName ?? throw new ArgumentNullException(nameof(homeName));
    }

    public void UpdateAddress(string? address, string? city, string? state, string? country, string? postalCode)
    {
        Address = address;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        UpdatedAt = DateTime.UtcNow;
    }
}