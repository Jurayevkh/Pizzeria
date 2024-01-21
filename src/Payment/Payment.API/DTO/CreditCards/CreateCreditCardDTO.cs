namespace Payment.API.DTOs.CreditCards;

public class CreateCreditCardDTO
{
    public string CustomerPhoneNumber { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
}

