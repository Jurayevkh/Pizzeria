namespace AccountCatalog.Application.UseCases.Customers.Commands;

public class UpdateCustomerCommand:IRequest<bool>
{
    public string PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumberChange { get; set; }
    public string? Password { get; set; }
}

