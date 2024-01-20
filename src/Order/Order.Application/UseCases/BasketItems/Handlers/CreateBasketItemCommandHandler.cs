namespace Order.Application.UseCases.BasketItems.Handlers;
using Order.Domain.Entities.Basket;

public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateBasketItemCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var basket = await _applicationDbContext.Baskets.FirstOrDefaultAsync(basket=>basket.CustomerId==request.CustomerId);
            BasketItems basketItem = new BasketItems()
            {
                BasketId = basket.Id,
                ProductId=request.ProductId
            };
            await _applicationDbContext.BasketItems.AddAsync(basketItem);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

