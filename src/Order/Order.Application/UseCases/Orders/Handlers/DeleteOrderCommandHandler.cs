using Order.Application.UseCases.Orders.Commands;

namespace Order.Application.UseCases.Orders.Handlers;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteOrderCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var order = await _applicationDbContext.Orders.FirstOrDefaultAsync(order=>order.Id==request.OrderId);
            if (order is null)
                return false;
            _applicationDbContext.Orders.Remove(order);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

