namespace About.Application.UseCases.Promocodes.Commands;

public class CreatePromocodeCommand:IRequest<bool>
{
    public string Promocode { get; set; }
    public float SumOfDiscount { get; set; }
    public int Days { get; set; }
}

