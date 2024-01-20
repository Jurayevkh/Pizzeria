namespace Order.Domain.Entities.Order;

public class Orders:BaseEntity
{
    public int CustomerId { get; set; }
    public string DeliveryAddress { get; set; }
    public float TotalAmound { get; set; }
}

