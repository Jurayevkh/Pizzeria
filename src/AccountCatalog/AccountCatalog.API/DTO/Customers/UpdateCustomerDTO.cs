namespace AccountCatalog.API.DTO.Customers;

public class UpdateCustomerDTO
{
    public string PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumberChange { get; set; }
    public string? Password { get; set; }
    public int? RoleId { get; set; }
}

