namespace Order.Application.UseCases.BasketItems.Commands;

public class CreateBasketItemCommand:IRequest<bool>
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}

