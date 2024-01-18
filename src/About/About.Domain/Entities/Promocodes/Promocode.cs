namespace About.Domain.Entities.Promocodes;

public class Promocode:BaseEntity
{
    public string Promokod { get; set; }
    public float SumOfDiscount { get; set; }
    public DateTime ExpiryDate { get; set;}
}

