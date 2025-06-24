namespace MDispenser.Domain.Entities;
public class UserHomeAccess
{
    public int AccessId { get; private set; }
    public int UserId { get; private set; }
    public int HomeId { get; private set; }
    public int RoleId { get; private set; }
    public DateTime GrantedAt { get; private set; } = DateTime.UtcNow;
    public int? GrantedById { get; private set; }

    // Navigation properties
    public User User { get; private set; }
    public Home Home { get; private set; }
    public Role Role { get; private set; }
    public User? GrantedBy { get; private set; }

    public UserHomeAccess(int userId, int homeId, int roleId, int? grantedById = null)
    {
        UserId = userId;
        HomeId = homeId;
        RoleId = roleId;
        GrantedById = grantedById;
    }
}