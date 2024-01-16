namespace Payment.Application.UseCases.Payments.Queries;
using Payment.Domain.Entities.Payment;

public class GetAllPaymentsByOrderIdQuery:IRequest<Payments>
{
    public int OrderId { get; set; }
}

