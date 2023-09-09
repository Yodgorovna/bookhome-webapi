namespace BookHome.Domain.Entities.Books;

public class BookAuthors : Auditable
{
    public long BookId { get; set; }    

    public long AuthorId { get; set; }
    
}
