using Order.Application.UseCases.OrderItems.Commands;

namespace Order.Application.UseCases.OrderItems.Handlers;

public class DeleteOrderItemsCommandHandler : IRequestHandler<DeleteOrderItemsCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteOrderItemsCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteOrderItemsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var orderItems = await _applicationDbContext.OrderItems.FirstOrDefaultAsync(orderitems=>orderitems.OrderId==request.OrderId && orderitems.ProductId==request.ProductId);
            if (orderItems is null)
                return false;
            _applicationDbContext.OrderItems.Remove(orderItems);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

