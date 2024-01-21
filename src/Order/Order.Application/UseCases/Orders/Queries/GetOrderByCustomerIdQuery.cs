namespace Order.Application.UseCases.Orders.Queries;
using Order.Domain.Entities.Order;

public class GetOrderByCustomerIdQuery:IRequest<List<Orders>>
{
    public int CustomerId { get; set; }
}

