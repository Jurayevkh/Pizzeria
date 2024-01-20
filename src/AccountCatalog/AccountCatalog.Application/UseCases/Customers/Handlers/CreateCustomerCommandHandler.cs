namespace AccountCatalog.Application.UseCases.Customers.Handlers;
using AccountCatalog.Domain.Entities.Customer;
using System;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;


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
            if (customer != null)
                return false;
            Customers customers = new Customers()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password,
                RoleId=2
            };

            await _applicationDbContext.Customers.AddAsync(customers);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            var cookieoptions = new CookieOptions();
            cookieoptions.Expires = DateTime.UtcNow.AddDays(1);
            cookieoptions.Path = "/";
            
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

