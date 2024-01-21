namespace Order.Application.UseCases.OrderItems.Queries;
using Order.Domain.Entities.Order;


public class GetAllOrderItemByOrderQuery:IRequest<List<OrderItems>>
{
    public int OrderId { get; set; }
}

