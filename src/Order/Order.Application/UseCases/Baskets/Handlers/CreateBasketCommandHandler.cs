namespace Order.Application.UseCases.Baskets.Handlers;
using Order.Domain.Entities.Basket;

public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateBasketCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Baskets basket = new Baskets()
            {
                CustomerId=request.CustomerId,
                Status=request.Status??"Empty"
            };
            await _applicationDbContext.Baskets.AddAsync(basket);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

