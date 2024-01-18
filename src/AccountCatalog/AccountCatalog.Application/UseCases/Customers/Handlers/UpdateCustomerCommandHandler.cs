namespace AccountCatalog.Application.UseCases.Customers.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateCustomerCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(customer=>customer.PhoneNumber==request.PhoneNumber);
            if (customer is null)
                return false;
            customer.FirstName = request.FirstName ?? customer.FirstName;
            customer.LastName = request.LastName ?? customer.LastName;
            customer.PhoneNumber = request.PhoneNumberChange ?? customer.PhoneNumber;
            customer.Password = request.Password ?? customer.Password;
            _applicationDbContext.Customers.Update(customer);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

