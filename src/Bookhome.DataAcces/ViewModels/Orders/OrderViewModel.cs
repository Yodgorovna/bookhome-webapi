namespace Bookhome.DataAcces.ViewModels.Orders;

public class OrderViewModel
{
    public long OrderId { get; set; }

    public string Status { get; set; } = string.Empty;

    public string BookName { get; set; } = String.Empty;

    public Int16 DiscountPercentage { get; set; }

    public int Quantity { get; set; }

    public float TotalPrice { get; set; }

    public bool IsContracted { get; set; }

    public bool IsPaid { get; set; }
}
