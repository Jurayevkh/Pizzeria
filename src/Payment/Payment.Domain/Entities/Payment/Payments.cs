namespace Payment.Domain.Entities.Payment;

public class Payments:BaseEntity
{
    public int OrderId { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public string PaymentMethod { get; set;}
    public int? CardId { get; set; }
    public int? PromoCodeId { get; set; }

}

