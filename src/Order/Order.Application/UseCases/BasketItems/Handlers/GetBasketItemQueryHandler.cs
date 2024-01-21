namespace Order.Application.UseCases.BasketItems.Handlers;

using System.Threading;
using System.Threading.Tasks;
using Order.Domain.Entities.Basket;

public class GetBasketItemQueryHandler : IRequestHandler<GetAllBasketItemByBasketQuery, List<BasketItems>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetBasketItemQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }



    async Task<List<BasketItems>> IRequestHandler<GetAllBasketItemByBasketQuery, List<BasketItems>>.Handle(GetAllBasketItemByBasketQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.BasketItems.Where(basketItem => basketItem.BasketId == request.BasketId).ToListAsync();
    }
}

