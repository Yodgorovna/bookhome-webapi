namespace BookHome.Domain.Entities.Books;

public class BookImageUpdateDto
{
    public long BookId { get; set; }

    public string ImagePath { get; set; } = string.Empty;
}
