namespace About.Application.UseCases.Promocodes.Handlers;

public class GetPromocodeByPromocodeQueryHandler : IRequestHandler<GetPromocodeByPromocodeQuery, Promocode>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetPromocodeByPromocodeQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Promocode> Handle(GetPromocodeByPromocodeQuery request, CancellationToken cancellationToken)
    {
        var promocode = await _applicationDbContext.Promocodes.FirstOrDefaultAsync(promocode=>promocode.Promokod==request.Promocode);
        return promocode;
    }
}

