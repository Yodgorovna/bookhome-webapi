namespace BookHome.Persistance.Dtos.Orders;

public class OrderUpdateDto
{
    public long UserId { get; set; }

    public string Status { get; set; } = string.Empty;

    public double BookPrice { get; set; }

    public double DeliveryPrice { get; set; }

    public double ResultPrice { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string PaymentType { get; set; } = string.Empty;

    public bool IsPaid { get; set; }

    public bool IsContracted { get; set; }

    public string Description { get; set; } = string.Empty;
}
