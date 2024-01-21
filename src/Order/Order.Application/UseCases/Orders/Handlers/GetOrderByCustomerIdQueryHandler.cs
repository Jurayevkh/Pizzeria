namespace Order.Application.UseCases.Orders.Handlers;

using System.Threading;
using System.Threading.Tasks;
using Order.Application.UseCases.Orders.Queries;
using Order.Domain.Entities.Order;

public class GetOrderByCustomerIdQueryHandler : IRequestHandler<GetOrderByCustomerIdQuery, List<Orders>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetOrderByCustomerIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Orders>> Handle(GetOrderByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Orders.Where(orders => orders.CustomerId == request.CustomerId).ToListAsync();
    }
}

