namespace About.Application.UseCases.Promocodes.Handlers;

public class DeletePromocodeCommandHandler : IRequestHandler<DeletePromocodeCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeletePromocodeCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeletePromocodeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var promocode = await _applicationDbContext.Promocodes.FirstOrDefaultAsync(promocode=>promocode.Promokod==request.Promocode);

            if (promocode is null)
                return false;
            _applicationDbContext.Promocodes.Remove(promocode);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

