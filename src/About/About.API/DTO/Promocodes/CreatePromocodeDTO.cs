namespace About.API.DTO.Promocodes;

public class CreatePromocodeDTO
{
    public string Promocode { get; set; }
    public float SumOfDiscount { get; set; }
    public int Days { get; set; }
}

