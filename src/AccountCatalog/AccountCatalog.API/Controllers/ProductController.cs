using AccountCatalog.API.DTO.Customers;
using AccountCatalog.API.DTO.Products;
using AccountCatalog.Application.UseCases.Customers.Commands;
using AccountCatalog.Application.UseCases.Customers.Queries;
using AccountCatalog.Application.UseCases.Products.Commands;
using AccountCatalog.Application.UseCases.Products.Queries;

namespace AccountCatalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProduct()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetProductByNameQuery(string Name)
        {
            var product = await _mediator.Send(new GetProductByNameQuery() { Name=Name});
            return Ok(product);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductByCategoryQuery(string CategoryName)
        {
            var products = await _mediator.Send(new GetAllProductByCategoryQuery() { CategoryName = CategoryName });
            return Ok(products);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            CreateProductCommand product = new CreateProductCommand()
            {
                CategoryName = createProductDTO.CategoryName,
                ImagePath = createProductDTO.ImagePath,
                Name = createProductDTO.Name,
                Price = createProductDTO.Price,
                Recipe = createProductDTO.Recipe
            };
            var result = await _mediator.Send(product);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            UpdateProductCommand product = new UpdateProductCommand()
            {
                CategoryName = updateProductDTO.CategoryName,
                ImagePath = updateProductDTO.ImagePath,
                Name = updateProductDTO.Name,
                OldName = updateProductDTO.OldName,
                Price = updateProductDTO.Price,
                Recipe = updateProductDTO.Recipe
            };
            var result = await _mediator.Send(product);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProduct(string Name)
        {
            var result = await _mediator.Send(new DeleteProductCommand() {Name=Name});
            return Ok(result);
        }
    }
}

