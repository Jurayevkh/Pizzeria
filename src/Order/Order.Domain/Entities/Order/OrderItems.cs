namespace Order.Domain.Entities.Order;

public class OrderItems:BaseEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int SubTotal { get; set; }
}

