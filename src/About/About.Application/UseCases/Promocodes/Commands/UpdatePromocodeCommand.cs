namespace About.Application.UseCases.Promocodes.Commands;

public class UpdatePromocodeCommand:IRequest<bool>
{
    public string OldPromocode { get; set; }
    public string? Promocode { get; set; }
    public float? SumOfDisscount { get; set; }
    public int? Days { get; set; }
}

