namespace AccountCatalog.Application.UseCases.Customers.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteCustomerCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _applicationDbContext.Customers.FirstOrDefaultAsync(customer=>customer.PhoneNumber==request.PhoneNumber);
            if (customer is null)
                return false;
            _applicationDbContext.Customers.Remove(customer);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

