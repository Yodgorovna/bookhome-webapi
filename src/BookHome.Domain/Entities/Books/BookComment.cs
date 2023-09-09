namespace BookHome.Domain.Entities.Books;

public class BookComment : Auditable
{
    public long BookId { get; set; }        

    public long UserId { get; set; }   

    public string Comment { get; set; } = string.Empty; 

    public bool IsEdited { get; set; } 

}

