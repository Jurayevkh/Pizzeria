namespace Payment.Application.UseCases.CreditCards.Handlers;

using Payment.Domain.Entities.CreditCard;


public class GetCreditCardByCardNumberQueryHandler : IRequestHandler<GetCreditCardByCardNumberQuery, CreditCards>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetCreditCardByCardNumberQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<CreditCards> Handle(GetCreditCardByCardNumberQuery request, CancellationToken cancellationToken)
    {
        CreditCards? creditCards = await _applicationDbContext.CreditCards.FirstOrDefaultAsync(cc=>cc.CardNumber==request.CardNumber);

        creditCards = creditCards ?? throw new Exception("Card not found");

        return creditCards;
    }
}

