using Order.Application.UseCases.Baskets.Commands;
using Order.Application.UseCases.Baskets.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetBasketByCustomerId(int CustomerId)
        {
            var result = await _mediator.Send(new GetBasketByCustomerIdQuery() { CustomerId=CustomerId});
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateBasket(int CustomerId)
        {
            var basket = await _mediator.Send(new CreateBasketCommand() { CustomerId=CustomerId , Status="Empty"});
            return Ok(basket);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateBasket(int CustomerId , string status) 
        {
            var result = await _mediator.Send(new UpdateBasketCommand() { CustomerId=CustomerId,status=status});
            return Ok(result);
        }
    }
}

