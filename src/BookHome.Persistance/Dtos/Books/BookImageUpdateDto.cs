using Microsoft.AspNetCore.Http;

namespace BookHome.Domain.Entities.Books;

public class BookImageUpdateDto
{
    public IFormFile ImagePath { get; set; } = default!;
}
