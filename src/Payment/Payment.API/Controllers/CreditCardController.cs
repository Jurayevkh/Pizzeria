namespace Payment.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CreditCardController : Controller
    {

        private readonly IMediator _mediator;

        public CreditCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCreditCard()
        {
            var creditCards = await _mediator.Send(new GetAllCreditCardQuery());
            return Ok(creditCards);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetCreditCard(string CardNumber)
        {
            var creditCard = await _mediator.Send(new GetCreditCardByCardNumberQuery() {CardNumber=CardNumber});
            return Ok(creditCard);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCreditCard(CreateCreditCardDTO createCreditCardDTO)
        {
            CreateCreditCardCommand creditCards = new CreateCreditCardCommand()
            {
                CustomerPhoneNumber=createCreditCardDTO.CustomerPhoneNumber,
                CardNumber=createCreditCardDTO.CardNumber,
                ExpiryDate=createCreditCardDTO.ExpiryDate,
                CVV=createCreditCardDTO.CVV
            };

            var creditCard = await _mediator.Send(creditCards);
            return Ok(creditCard);
        }

    }
}

