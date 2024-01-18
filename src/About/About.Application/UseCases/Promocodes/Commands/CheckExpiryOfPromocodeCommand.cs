namespace About.Application.UseCases.Promocodes.Queries;

public class CheckExpiryOfPromocodeCommand:IRequest<bool>
{
    public string Promocode { get; set; }
}

