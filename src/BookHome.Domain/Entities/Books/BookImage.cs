namespace BookHome.Domain.Entities.Books;

public class BookImage : Auditable
{
    public long BookId { get; set; }    

    public string ImagePath { get; set; } = string.Empty;
}
