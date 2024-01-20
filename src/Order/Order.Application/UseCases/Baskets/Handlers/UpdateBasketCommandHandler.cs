namespace Order.Application.UseCases.Baskets.Handlers;

public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateBasketCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var basket = await _applicationDbContext.Baskets.FirstOrDefaultAsync(basket=>basket.CustomerId==request.CustomerId);
            basket.Status = request.status;
            _applicationDbContext.Baskets.Update(basket);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

