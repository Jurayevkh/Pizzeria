namespace AccountCatalog.Application.UseCases.Customers.Commands;

public class CreateCustomerCommand:IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

