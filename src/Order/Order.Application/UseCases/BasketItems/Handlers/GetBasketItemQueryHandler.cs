namespace Order.Application.UseCases.BasketItems.Handlers;

using System.Threading;
using System.Threading.Tasks;
using Order.Domain.Entities.Basket;

public class GetBasketItemQueryHandler : IRequestHandler<GetAllBasketItemByBasketQuery, BasketItems>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetBasketItemQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public async Task<BasketItems> Handle(GetAllBasketItemByBasketQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.BasketItems.FirstOrDefaultAsync(basketItem => basketItem.BasketId==request.BasketId);
    }
}

