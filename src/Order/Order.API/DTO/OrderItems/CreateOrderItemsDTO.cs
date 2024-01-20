namespace Order.API.DTO.OrderItems;

public class CreateOrderItemsDTO
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public float SubTotal { get; set; }
}

