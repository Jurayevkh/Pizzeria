namespace Order.Application.UseCases.BasketItems.Queries;
using Order.Domain.Entities.Basket;

public class GetAllBasketItemByBasketQuery:IRequest<BasketItems>
{
    public int BasketId { get; set; }
}

