namespace BookHome.Domain.Entities.Orders;

public class OrderDetail : Auditable
{
    public long OrderId { get; set; }   

    public long BookId { get; set; } 

    public int Quantity { get; set; }   

    public double TotalPrice { get; set; } 
    
    public double DiscountPrice { get; set; } 
    
    public double ResultPrice { get; set; } 

}

