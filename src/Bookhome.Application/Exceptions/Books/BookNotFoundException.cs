namespace Bookhome.Application.Exceptions.Books;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException()
    {
        this.TitleMessage = "Book not found!";
    }
}
