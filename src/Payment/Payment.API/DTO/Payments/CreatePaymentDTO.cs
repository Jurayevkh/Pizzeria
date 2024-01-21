namespace Payment.API.DTOs.Payments;

public class CreatePaymentDTO
{
    public int OrderId { get; set; }
    public int CardId { get; set; }
    public string? Promocode { get; set; }
}

