namespace BookHome.Persistance.Dtos.Books;

public class BookComentUpdateDto
{
    public long BookId { get; set; }

    public long UserId { get; set; }

    public string Comment { get; set; } = string.Empty;

    public bool IsEdited { get; set; }
}
