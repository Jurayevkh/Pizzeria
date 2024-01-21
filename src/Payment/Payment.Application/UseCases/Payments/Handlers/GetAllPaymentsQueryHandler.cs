namespace Payment.Application.UseCases.Payments.Handlers;
using Payment.Domain.Entities.Payment;

public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<Payments>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllPaymentsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Payments>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Payments.ToListAsync();
    }
}

