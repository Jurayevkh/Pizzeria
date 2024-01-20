namespace Order.API.DTO.Orders;

public class CreateOrderDTO
{
    public int CustomerId { get; set; }
    public string DeliveryAddress { get; set; }
    public float TotalAmount { get; set; }
}

