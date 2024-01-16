namespace Payment.Application.UseCases.Payments.Commands;

public class CreatePaymentCommand:IRequest<bool>
{
    public int OrderId { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    public int? CardId { get; set; }
    public int? PromoCodeId { get; set; }
}

