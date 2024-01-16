namespace Payment.API.DTOs.Payments;

public class CreatePaymentDTO
{
    public int OrderId { get; set; }
    public string PaymentMethod { get; set; }
    public string Promocode { get; set; }
}

