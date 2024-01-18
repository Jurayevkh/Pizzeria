namespace About.Application.UseCases.Promocodes.Commands;

public class DeletePromocodeCommand:IRequest<bool>
{
    public string Promocode { get; set; }
}

