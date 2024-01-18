namespace AccountCatalog.Application.UseCases.Customers.Handlers;
using AccountCatalog.Domain.Entities.Customer;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customers>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCustomersQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Customers>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Customers.ToListAsync();
    }
}

