namespace Order.Domain.Entities.Basket;

public class Baskets:BaseEntity
{
    public int CustomerId { get; set; }
    public string Status { get; set; }
}

