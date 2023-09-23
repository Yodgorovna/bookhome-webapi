namespace BookHome.Persistance.Dtos.Users;

public class UserSecurityUpdate
{
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string ReturnNewPassword { get; set; } = string.Empty;
}
