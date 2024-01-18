namespace About.Application.UseCases.Promocodes.Handlers;

public class UpdatePromocodeCommandHandler : IRequestHandler<UpdatePromocodeCommand, bool>
{
    private readonly IApplicationDbContext _applicationdDbContext;

    public UpdatePromocodeCommandHandler(IApplicationDbContext applicationdDbContext)
    {
        _applicationdDbContext = applicationdDbContext;
    }

    public async Task<bool> Handle(UpdatePromocodeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var promocode = await _applicationdDbContext.Promocodes.FirstOrDefaultAsync(promocode=>promocode.Promokod==request.OldPromocode);
            if (promocode is null)
                return false;
            promocode.Promokod = request.Promocode ?? promocode.Promokod;
            promocode.SumOfDiscount = request.SumOfDisscount ?? promocode.SumOfDiscount;
            if (request.Days != null)
                promocode.ExpiryDate = promocode.ExpiryDate.AddDays((double)request.Days);
            _applicationdDbContext.Promocodes.Update(promocode);
            var result = await _applicationdDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

