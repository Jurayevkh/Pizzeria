namespace Order.Application.UseCases.Baskets.Commands;

public class CreateBasketCommand:IRequest<bool>
{
    public int CustomerId { get; set; }
    public string Status { get; set; }
}

