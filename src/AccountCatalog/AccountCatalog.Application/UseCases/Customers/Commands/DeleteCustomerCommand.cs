namespace AccountCatalog.Application.UseCases.Customers.Commands;

public class DeleteCustomerCommand:IRequest<bool>
{
    public string PhoneNumber { get; set; }
}

