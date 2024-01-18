namespace About.Application.UseCases.Promocodes.Queries;

public class GetPromocodeByPromocodeQuery:IRequest<Promocode>
{
    public string Promocode { get; set; }
}

