
using About.Application.UseCases.Promocodes.Commands;

namespace About.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PromocodeController : Controller
    {
        private readonly IMediator _mediator;

        public PromocodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllPromocode()
        {
            var promocodes = await _mediator.Send(new GetAllPromocodeQuery());
            return Ok(promocodes);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPromocodeByPromocode(string Promocode)
        {
            var promocode = await _mediator.Send(new GetPromocodeByPromocodeQuery { Promocode = Promocode });
            return Ok(promocode);
        }

        [HttpGet]
        public async ValueTask<IActionResult> CheckPromocode(string Promcode)
        {
            var promocode = await _mediator.Send(new CheckExpiryOfPromocodeCommand { Promocode=Promcode});
            return Ok(promocode);
        }


        [HttpPost]
        public async ValueTask<IActionResult> CreatePromocode(CreatePromocodeDTO createPromocodeDTO)
        {
            if (createPromocodeDTO.Days < 0 || createPromocodeDTO.SumOfDiscount < 0)
                return Ok(false);

            CreatePromocodeCommand promocode = new CreatePromocodeCommand()
            {
                Promocode = createPromocodeDTO.Promocode,
                SumOfDiscount = createPromocodeDTO.SumOfDiscount,
                Days = createPromocodeDTO.Days
            };
            var result = await _mediator.Send(promocode);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdatePromocode(UpdatePromocodeDTO updatePromocodeDTO)
        {
            if (updatePromocodeDTO.Days < 0 || updatePromocodeDTO.SumOfDisscount < 0)
                return Ok(false);
            UpdatePromocodeCommand promocode = new UpdatePromocodeCommand()
            {
               OldPromocode = updatePromocodeDTO.OldPromocode,
               Promocode=updatePromocodeDTO.Promocode,
               SumOfDisscount=updatePromocodeDTO.SumOfDisscount,
               Days=updatePromocodeDTO.Days
            };
            var result = await _mediator.Send(promocode);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletePromocode(string Promocode)
        {
            var result = await _mediator.Send(new DeletePromocodeCommand() { Promocode = Promocode });
            return Ok(result);
        }
    }
}

