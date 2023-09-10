namespace Bookhome.Application.Exception.Authors;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException()
    {
        this.TitleMessage = "Author not found!";
    }
}
