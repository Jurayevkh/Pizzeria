namespace Order.Application.UseCases.Baskets.Handlers;
using Order.Domain.Entities.Basket;

public class GetBasketByCustomerIdQueryHandler : IRequestHandler<GetBasketByCustomerIdQuery, Baskets>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetBasketByCustomerIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Baskets> Handle(GetBasketByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Baskets.FirstOrDefaultAsync(basket=>basket.CustomerId==request.CustomerId);
    }
}

