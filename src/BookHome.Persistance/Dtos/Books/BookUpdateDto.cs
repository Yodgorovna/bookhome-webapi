namespace BookHome.Persistance.Dtos.Books;

public class BookUpdateDto
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Price { get; set; }

    public bool IsHardCover { get; set; }
}
