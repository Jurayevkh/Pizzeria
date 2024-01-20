namespace Order.Application.UseCases.OrderItems.Handlers;
using Order.Domain.Entities.Order;

public class GetAllOrderItemsByOrderQueryHandler : IRequestHandler<GetAllOrderItemByOrderQuery, List<OrderItems>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllOrderItemsByOrderQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<OrderItems>> Handle(GetAllOrderItemByOrderQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.OrderItems.Where(orderitems=>orderitems.OrderId==request.OrderId).ToListAsync();
    }
}

