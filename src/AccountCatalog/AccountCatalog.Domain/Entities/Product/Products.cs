namespace AccountCatalog.Domain.Entities.Product;

public class Products:BaseEntity
{
    public string Name { get; set; }
    public float Price { get; set; }
    public string Recipe { get; set; }
    public string ImagePath { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

