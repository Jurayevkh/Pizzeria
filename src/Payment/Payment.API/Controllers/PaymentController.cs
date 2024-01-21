using Payment.Application.UseCases.Payments.Queries;

namespace Payment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatePayment(CreatePaymentDTO createPaymentDTO)
        {
            CreatePaymentCommand payment = new CreatePaymentCommand()
            {
                OrderId=createPaymentDTO.OrderId,
                PromoCode=createPaymentDTO.Promocode,
                CardId=createPaymentDTO.CardId
            };
            var payments = await _mediator.Send(payment);
            return Ok(payments);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllPayments()
        {
            var payments = await _mediator.Send(new GetAllPaymentsQuery());
            return Ok(payments);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPaymentsByOrderId(int OrderId)
        {
            var payments = await _mediator.Send(new GetAllPaymentsByOrderIdQuery() { OrderId=OrderId});
            return Ok(payments);
        }
    }
}

