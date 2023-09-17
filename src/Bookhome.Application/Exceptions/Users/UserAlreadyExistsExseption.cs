namespace Bookhome.Application.Exceptions.Users;

public class UserAlreadyExistsExseption : AlreadyExistsException
{
    public UserAlreadyExistsExseption()
    {
        TitleMessage = "User already exists";
    }

    public UserAlreadyExistsExseption(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
