
namespace AccountCatalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllCategory()
        {
            var categories = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(categories);
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
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCategory(string OldName,string NewName)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand() { OldName=OldName,NewName=NewName});
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCategory(string Name)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand() { Name = Name });
            return Ok(result);
        }
    }
}

