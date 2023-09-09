namespace BookHome.Domain.Entities.Discounts;

public class Discount : Auditable
{
    public string Name { get; set; } = string.Empty;    

    public string Description { get; set; } = string.Empty; 

}
