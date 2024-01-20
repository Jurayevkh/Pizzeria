namespace Order.Application.UseCases.Baskets.Commands;

public class UpdateBasketCommand:IRequest<bool>
{
    public int CustomerId { get; set; }
    public string status { get; set; }
}

