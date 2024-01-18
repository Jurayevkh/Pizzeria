namespace About.Application.UseCases.Promocodes.Handlers;

public class GetAllPromocodeQueryHandler : IRequestHandler<GetAllPromocodeQuery, List<Promocode>>
{
    private readonly IApplicationDbContext _applcationDbContext;

    public GetAllPromocodeQueryHandler(IApplicationDbContext applcationDbContext)
    {
        _applcationDbContext = applcationDbContext;
    }

    public async Task<List<Promocode>> Handle(GetAllPromocodeQuery request, CancellationToken cancellationToken)
    {
        return await _applcationDbContext.Promocodes.ToListAsync();
    }
}

