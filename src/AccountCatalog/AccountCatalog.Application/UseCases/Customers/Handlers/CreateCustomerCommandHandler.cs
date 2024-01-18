namespace AccountCatalog.Application.UseCases.Customers.Handlers;
using AccountCatalog.Domain.Entities.Customer;


public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCustomerCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(customer=>customer.PhoneNumber==request.PhoneNumber);
            if (customer is null)
                return false;
            Customers customers = new Customers()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password
            };

            await _applicationDbContext.Customers.AddAsync(customers);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

