namespace Order.Application.UseCases.OrderItems.Commands;

public class DeleteOrderItemsCommand:IRequest<bool>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}

