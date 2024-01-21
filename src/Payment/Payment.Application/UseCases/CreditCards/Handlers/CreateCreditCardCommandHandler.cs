namespace Payment.Application.UseCases.CreditCards.Handlers;
using Payment.Domain.Entities.CreditCard;

public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCreditCardCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreditCards creditCards = new CreditCards()
            {
                CustomerId=1,
                //CustomerId = request.CustomerPhoneNumber,
                CardNumber = request.CardNumber,
                ExpiryDate = request.ExpiryDate,
                CVV = request.CVV
            };

            await _applicationDbContext.CreditCards.AddAsync(creditCards);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

