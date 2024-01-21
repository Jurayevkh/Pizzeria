using Order.Application.UseCases.OrderItems.Commands;
using Order.Application.UseCases.OrderItems.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllOrderItemsByOrder(int OrderId)
        {
            var result = await _mediator.Send(new GetAllOrderItemByOrderQuery() { OrderId = OrderId });
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteOrderItems(int OrderId, int ProductId)
        {
            var result = await _mediator.Send(new DeleteOrderItemsCommand() { OrderId=OrderId,ProductId=ProductId});
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateOrderItem(int OrderId,int ProductId)
        {
            CreateOrderItemsCommand orderItem = new CreateOrderItemsCommand()
            {
                OrderId = OrderId,
                ProductId = ProductId,
                Quantity = 1
            };
            var result = await _mediator.Send(orderItem);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrderItemQuantity(int OrderId, int ProductId)
        {
            var result = await _mediator.Send(new UpdateOrderItemsCommand() { OrderId=OrderId,ProductId=ProductId,Quantity=1});
            return Ok();
        }
    }
}

