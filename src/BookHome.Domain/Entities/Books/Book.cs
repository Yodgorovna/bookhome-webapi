namespace BookHome.Domain.Entities.Books;

public class Book : Auditable
{
    public long CategoryId { get; set; }   
    
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty; 

    public double Price { get; set; } 

    public bool IsHardCover { get; set; }  

}
