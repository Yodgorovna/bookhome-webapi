using Microsoft.AspNetCore.Http;

namespace BookHome.Persistance.Dtos.Books;

public class BookCreateDto
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Price { get; set; }

    public bool IsHardCover { get; set; }

    public List<IFormFile> ImagePath { get; set; } = default!;
}
