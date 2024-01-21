
using System.Text.Json;
using About.API.DTO.Promocodes;
using About.Application.UseCases.Promocodes.Commands;
using About.Domain.Entities.Promocodes;
using Microsoft.Extensions.Caching.Distributed;

namespace About.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PromocodeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public PromocodeController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllPromocode()
        {
        
            var fromCache = await _distributedCache.GetStringAsync("GetAllPromocode");

            if (fromCache is null)
            {
                var promocodes = await _mediator.Send(new GetAllPromocodeQuery());

                if (!promocodes.Any())
                    return Ok();

                fromCache = JsonSerializer.Serialize(promocodes);
                await _distributedCache.SetStringAsync("GetAllPromocode", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<List<Promocode>>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetPromocodeByPromocode(string Promocode)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Promocode{Promocode}");

            if (fromCache is null)
            {
                var promocodes = await _mediator.Send(new GetPromocodeByPromocodeQuery { Promocode = Promocode });

                if (promocodes is null)
                    return Ok();

                fromCache = JsonSerializer.Serialize(promocodes);
                await _distributedCache.SetStringAsync($"Promocode{Promocode}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<Promocode>(fromCache);
            return Ok(result);
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

            await _distributedCache.RemoveAsync($"Promocode{createPromocodeDTO.Promocode}");
            await _distributedCache.RemoveAsync("GetAllPromocode");

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

            await _distributedCache.RemoveAsync($"Promocode{promocode.Promocode}");
            await _distributedCache.RemoveAsync("GetAllPromocode");

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletePromocode(string Promocode)
        {
            var result = await _mediator.Send(new DeletePromocodeCommand() { Promocode = Promocode });
            await _distributedCache.RemoveAsync($"Promocode{Promocode}");
            await _distributedCache.RemoveAsync("GetAllPromocode");

            return Ok(result);
        }
    }
}

