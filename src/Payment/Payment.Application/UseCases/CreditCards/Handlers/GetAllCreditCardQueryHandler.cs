namespace Payment.Application.UseCases.CreditCards.Handlers;

using Microsoft.EntityFrameworkCore;
using Payment.Application.UseCases.CreditCards.Queries;
using Payment.Domain.Entities.CreditCard;


public class GetAllCreditCardQueryHandler : IRequestHandler<GetAllCreditCardQuery, List<CreditCards>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCreditCardQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<CreditCards>> Handle(GetAllCreditCardQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.CreditCards.ToListAsync(cancellationToken);
    }
}

