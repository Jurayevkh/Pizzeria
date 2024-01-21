using Order.Application.UseCases.BasketItems.Commands;
using Order.Application.UseCases.BasketItems.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BasketItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateBasketItem(int CustomerId, int ProductId)
        {
            var result = await _mediator.Send(new CreateBasketItemCommand() { CustomerId=CustomerId,ProductId=ProductId});
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteBasketItem(int BasketId,int ProductId)
        {
            var result = await _mediator.Send(new DeleteBasketItemCommand() { BasketId=BasketId,ProductId=ProductId});
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllBasketItemByBasket(int BasketId)
        {
            var result = await _mediator.Send(new GetAllBasketItemByBasketQuery() { BasketId=BasketId});
            return Ok(result);
        }
    }
}

