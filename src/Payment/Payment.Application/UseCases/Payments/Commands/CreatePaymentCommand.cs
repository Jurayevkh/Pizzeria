namespace Payment.Application.UseCases.Payments.Commands;

public class CreatePaymentCommand:IRequest<bool>
{
    public int OrderId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int CardId { get; set; }
    public string? PromoCode { get; set; }
}

