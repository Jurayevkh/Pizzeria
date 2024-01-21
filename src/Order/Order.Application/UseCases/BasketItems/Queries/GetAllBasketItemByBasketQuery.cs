namespace Order.Application.UseCases.BasketItems.Queries;
using Order.Domain.Entities.Basket;

public class GetAllBasketItemByBasketQuery:IRequest<List<BasketItems>>
{
    public int BasketId { get; set; }
}

