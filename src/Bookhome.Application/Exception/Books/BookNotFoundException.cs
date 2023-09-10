namespace Bookhome.Application.Exception.Books
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException()
        {
            this.TitleMessage = "Book not found!";
        }
    }
}
