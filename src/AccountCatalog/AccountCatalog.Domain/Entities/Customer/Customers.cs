namespace AccountCatalog.Domain.Entities.Customer;

public class Customers:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

