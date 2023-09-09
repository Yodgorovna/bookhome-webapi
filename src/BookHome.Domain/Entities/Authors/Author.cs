namespace BookHome.Domain.Entities.Authors;

public class Author : Auditable
{
    public string FirstName { get; set; } = string.Empty;   

    public string LastName { get; set; } = string.Empty;    

    public string Country { get; set; } = string.Empty;    
}
