namespace Order.Application.UseCases.Orders.Commands;

public class DeleteOrderCommand:IRequest<bool>
{
    public int OrderId { get; set; }
}

