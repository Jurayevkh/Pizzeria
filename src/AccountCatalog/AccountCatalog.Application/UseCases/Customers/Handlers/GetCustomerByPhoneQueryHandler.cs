namespace AccountCatalog.Application.UseCases.Customers.Handlers;
using AccountCatalog.Domain.Entities.Customer;


public class GetCustomerByPhoneQueryHandler : IRequestHandler<GetCustomerByPhoneQuery, Customers>
{
    private readonly IApplicationDbContext _applicationdDbContext;

    public GetCustomerByPhoneQueryHandler(IApplicationDbContext applicationdDbContext)
    {
        _applicationdDbContext = applicationdDbContext;
    }

    public async Task<Customers> Handle(GetCustomerByPhoneQuery request, CancellationToken cancellationToken)
    {
        return await _applicationdDbContext.Customers.FirstOrDefaultAsync(customer=>customer.PhoneNumber==request.PhoneNumber);
    }
}

