namespace BookHome.Persistance.Dtos.Books;

public class BookImageCreateDto
{
    public long BookId { get; set; }

    public string ImagePath { get; set; } = string.Empty;
}
