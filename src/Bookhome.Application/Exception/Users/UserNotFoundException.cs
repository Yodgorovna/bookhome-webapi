namespace Bookhome.Application.Exception.Users;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException()
    {
        this.TitleMessage = "User not found!";
    }
}
