namespace Payment.Application.UseCases.Payments.Handlers;

using Payment.Application.Refit;
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
            //var promocodeService = RestService.For<IPromocodeService>("https://localhost:7260/api/Promocode/");
            //var promocode = await promocodeService.GetPromocodeByPromocode(request.PromoCode);
            //if (promocode is null)
            //    return false;
            
            Payments payments = new Payments()
            {
                OrderId = request.OrderId,
                PaymentDate = request.PaymentDate,
                CardId = request.CardId
                //PromoCodeId = promocode.Id
            };
           

            await _applicationDbContext.Payments.AddAsync(payments);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
           return false;
        
    }
}

