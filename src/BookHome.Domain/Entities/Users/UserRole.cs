namespace BookHome.Domain.Entities.Users;

public class UserRole : Auditable
{
    public long UserId { get; set; }

    public long RoleId { get; set; }    

}
