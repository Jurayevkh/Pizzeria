using Order.Application.UseCases.Orders.Commands;
using Order.Application.UseCases.Orders.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetOrderByCustomerId(int CustomerId)
        {
            var result = await _mediator.Send(new GetOrderByCustomerIdQuery() { CustomerId=CustomerId});
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteOrder(int OrderId)
        {
            var result = await _mediator.Send(new DeleteOrderCommand() { OrderId = OrderId });
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateOrder(int CustomerId ,string DeliveryAddress)
        {
            var result = await _mediator.Send(new CreateOrderCommand() { CustomerId=CustomerId,DeliveryAddress=DeliveryAddress});
            return Ok(result);
        }
        
    }
}

