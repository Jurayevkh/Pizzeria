namespace Payment.Application.UseCases.CreditCards.Queries;
using Payment.Domain.Entities.CreditCard;

public class GetCreditCardByCardNumberQuery:IRequest<CreditCards>
{
    public string CardNumber { get; set; }
}

