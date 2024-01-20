namespace Order.Application.UseCases.OrderItems.Handlers;
using Order.Domain.Entities.Order;

public class CreateOrderItemCommandHandler:IRequestHandler<CreateOrderItemsCommand,bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateOrderItemCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateOrderItemsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isHaveOrderItem = await _applicationDbContext.OrderItems.FirstOrDefaultAsync(orderitem => orderitem.OrderId == request.OrderId || orderitem.ProductId == request.ProductId);
            if (isHaveOrderItem != null)
                return false;
            OrderItems orderItems = new OrderItems()
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
            };
            await _applicationDbContext.OrderItems.AddAsync(orderItems);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

