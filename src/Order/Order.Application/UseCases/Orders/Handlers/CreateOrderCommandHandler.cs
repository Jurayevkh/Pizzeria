namespace Order.Application.UseCases.Orders.Handlers;
using Order.Application.UseCases.Orders.Commands;
using Order.Domain.Entities.Order;


public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Orders order = new Orders(){};
            var orderItems = await _applicationDbContext.OrderItems.Where(orderitems => orderitems.OrderId == order.Id).ToListAsync();
            int orderTotal = 0;
            foreach(var order1 in orderItems)
            {
                orderTotal += order1.SubTotal;
            }
            order.CustomerId = request.CustomerId;
            order.DeliveryAddress = request.DeliveryAddress;
            order.TotalAmound = order.TotalAmound;
            await _applicationDbContext.Orders.AddAsync(order);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }

    }
}

