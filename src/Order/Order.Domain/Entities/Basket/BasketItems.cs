namespace Order.Domain.Entities.Basket;

public class BasketItems:BaseEntity
{
    public int BasketId { get; set; }
    public int ProductId { get; set; }
}

