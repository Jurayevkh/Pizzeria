namespace Payment.Application.UseCases.Payments.Handlers;

using Payment.Application.UseCases.Payments.Commands;
using Payment.Domain.Entities.CreditCard;
using Payment.Domain.Entities.Payment;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreatePaymentCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Payments payments=new Payments()
            {
                OrderId=request.OrderId,
                PaymentDate=request.PaymentDate,
                PaymentMethod=request.PaymentMethod,
                CardId=request.CardId,
                PromoCodeId=request.PromoCodeId
            };

            await _applicationDbContext.Payments.AddAsync(payments);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

