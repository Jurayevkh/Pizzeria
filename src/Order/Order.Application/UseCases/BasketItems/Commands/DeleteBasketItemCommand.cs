namespace Order.Application.UseCases.BasketItems.Commands;

public class DeleteBasketItemCommand:IRequest<bool>
{
    public int BasketId { get; set; }
    public int ProductId { get; set; }
}

