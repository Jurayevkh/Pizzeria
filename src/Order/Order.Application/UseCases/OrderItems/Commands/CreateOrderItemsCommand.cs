namespace Order.Application.UseCases.OrderItems.Commands;

public class CreateOrderItemsCommand:IRequest<bool>
{
       public int OrderId { get; set; }
       public int ProductId { get; set; }
       public int Quantity { get; set; }
}

