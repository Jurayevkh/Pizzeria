namespace AccountCatalog.Application.UseCases.Customers.Queries;
using AccountCatalog.Domain.Entities.Customer;

public class GetCustomerByPhoneQuery:IRequest<Customers>
{
    public string PhoneNumber { get; set; }
}

