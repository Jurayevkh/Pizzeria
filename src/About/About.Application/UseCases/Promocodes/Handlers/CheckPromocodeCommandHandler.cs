namespace About.Application.UseCases.Promocodes.Handlers;

public class CheckPromocodeCommandHandler : IRequestHandler<CheckExpiryOfPromocodeCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CheckPromocodeCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CheckExpiryOfPromocodeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var promocode = await _applicationDbContext.Promocodes.FirstOrDefaultAsync(promocode=>promocode.Promokod==request.Promocode);
            if (promocode is null || promocode.ExpiryDate<DateTime.Now)
                return false;
            return true;
        }
        catch
        {
            return false;
        }
    }
}

