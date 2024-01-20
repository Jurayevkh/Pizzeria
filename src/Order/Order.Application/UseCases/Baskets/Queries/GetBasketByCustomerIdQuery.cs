namespace Order.Application.UseCases.Baskets.Queries;
using Order.Domain.Entities.Basket;

public class GetBasketByCustomerIdQuery:IRequest<Baskets>
{
    public int CustomerId { get; set; }
}

