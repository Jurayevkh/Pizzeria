
using AccountCatalog.Domain.Entities.Category;

namespace AccountCatalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public CategoryController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCategory()
        {
            var fromCache = await _distributedCache.GetStringAsync("GetAllCategory");

            if (fromCache is null)
            {
                var categories = await _mediator.Send(new GetAllCategoryQuery());

                if (!categories.Any())
                    return Ok();

                fromCache = JsonSerializer.Serialize(categories);
                await _distributedCache.SetStringAsync("GetAllCategory", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<List<Categories>>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> CheckCategoryNameQuery(string Name)
        {
            var category = await _mediator.Send(new CheckCategoryNameQuery { Name = Name });
            return Ok(category);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCategory(string Name)
        {
            var result = await _mediator.Send(new CreateCategoryCommand() { Name=Name});
            await _distributedCache.RemoveAsync($"GetAllCategory");
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCategory(string OldName,string NewName)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand() { OldName=OldName,NewName=NewName});
            await _distributedCache.RemoveAsync($"GetAllCategory");
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCategory(string Name)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand() { Name = Name });
            await _distributedCache.RemoveAsync($"GetAllCategory");
            return Ok(result);
        }
    }
}

