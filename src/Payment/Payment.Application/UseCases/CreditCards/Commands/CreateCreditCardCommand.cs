namespace Payment.Application.UseCases.CreditCards.Commands;

public class CreateCreditCardCommand:IRequest<bool>
{
    public string CustomerPhoneNumber { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
}

