namespace Order.Application.UseCases.Orders.Commands;

public class CreateOrderCommand:IRequest<bool>
{
    public int CustomerId { get; set; }
    public string DeliveryAddress { get; set; }
}

