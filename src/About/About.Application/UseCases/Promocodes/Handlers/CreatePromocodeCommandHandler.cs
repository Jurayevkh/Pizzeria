using About.Domain.Entities.Branches;

namespace About.Application.UseCases.Promocodes.Handlers;

public class CreatePromocodeCommandHandler : IRequestHandler<CreatePromocodeCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreatePromocodeCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreatePromocodeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isHavePromocode = await _applicationDbContext.Promocodes.FirstOrDefaultAsync(promocode=>promocode.Promokod==request.Promocode);

            if (isHavePromocode != null)
                return false;
            Promocode promocode = new Promocode()
            {
                Promokod = request.Promocode,
                SumOfDiscount = request.SumOfDiscount,
                ExpiryDate = DateTime.UtcNow.AddDays(request.Days)
            };

            await _applicationDbContext.Promocodes.AddAsync(promocode);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
        
    }
}

