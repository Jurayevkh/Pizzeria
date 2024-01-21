namespace Payment.Application.UseCases.Payments.Handlers;
using Payment.Domain.Entities.Payment;

public class GetAllPaymentsByOrderIdQueryHandler : IRequestHandler<GetAllPaymentsByOrderIdQuery, List<Payments>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllPaymentsByOrderIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Payments>> Handle(GetAllPaymentsByOrderIdQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Payments.Where(payment => payment.OrderId == request.OrderId).ToListAsync();
    }
}

