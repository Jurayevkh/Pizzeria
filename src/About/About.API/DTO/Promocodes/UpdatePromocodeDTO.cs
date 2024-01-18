namespace About.API.DTO.Promocodes;

public class UpdatePromocodeDTO
{
    public string OldPromocode { get; set; }
    public string? Promocode { get; set; }
    public float? SumOfDisscount { get; set; }
    public int? Days { get; set; }
}

