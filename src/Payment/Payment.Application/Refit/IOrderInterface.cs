namespace Payment.Application.Refitl;

public interface IOrderInterface
{
}

public class OrderResult
{
    public int CustomerId { get; set; }
    public DateTime OrderedAt { get; set; }
    public string DeliveryAddress { get; set; }
    public float TotalAmound { get; set; }
}

