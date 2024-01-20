namespace Order.Application.UseCases.OrderItems.Handlers;

public class UpdateOrderItemsCommandHandler : IRequestHandler<UpdateOrderItemsCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateOrderItemsCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateOrderItemsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var orderItems = await _applicationDbContext.OrderItems.FirstOrDefaultAsync(orderItems=>orderItems.OrderId==request.OrderId && orderItems.ProductId==request.ProductId);
            if (orderItems is null)
                return false;
            orderItems.Quantity = request.Quantity;
            _applicationDbContext.OrderItems.Update(orderItems);
            var result=await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

