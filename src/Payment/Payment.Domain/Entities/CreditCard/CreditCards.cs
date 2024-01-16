namespace Payment.Domain.Entities.CreditCard;

public class CreditCards:BaseEntity
{
    public int CustomerId { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public string CVV { get; set; }
}

