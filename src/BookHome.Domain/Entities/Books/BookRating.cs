namespace BookHome.Domain.Entities.Books;

public class BookRating : Auditable
{
    public long BookId { get; set; }

    public long Rating { get; set;}

}
