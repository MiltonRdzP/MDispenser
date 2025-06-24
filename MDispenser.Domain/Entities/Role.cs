namespace MDispenser.Domain.Entities; 
public class Role
{
    public int RoleId { get; private set; }
    public string RoleName { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public ICollection<UserHomeAccess> UserHomeAccesses { get; private set; } = new List<UserHomeAccess>();

    public Role(string roleName)
    {
        RoleName = roleName ?? throw new ArgumentNullException(nameof(roleName));
    }
}
