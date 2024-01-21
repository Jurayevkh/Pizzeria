using AccountCatalog.API.DTO.Products;
using AccountCatalog.Application.UseCases.Products.Commands;
using AccountCatalog.Application.UseCases.Products.Queries;
using AccountCatalog.Domain.Entities.Customer;
using AccountCatalog.Domain.Entities.Product;

namespace AccountCatalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IMediator mediator, IDistributedCache distributedCache, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProduct()
        {
            var fromCache = await _distributedCache.GetStringAsync("GetAllProduct");

            if (fromCache is null)
            {
                var products = await _mediator.Send(new GetAllProductQuery());

                if (!products.Any())
                    return Ok();

                fromCache = JsonSerializer.Serialize(products);
                await _distributedCache.SetStringAsync("GetAllProduct", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<List<Products>>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetProductByNameQuery(string Name)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Product{Name}");

            if (fromCache is null)
            {
                var product = await _mediator.Send(new GetProductByNameQuery { Name = Name });

                if (product is null)
                    return Ok();

                fromCache = JsonSerializer.Serialize(product);
                await _distributedCache.SetStringAsync($"Product{Name}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<Products>(fromCache);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllProductByCategoryQuery(string CategoryName)
        {
            var fromCache = await _distributedCache.GetStringAsync("GetAllProductByCategory");

            if (fromCache is null)
            {
                var products = await _mediator.Send(new GetAllProductByCategoryQuery() { CategoryName=CategoryName});

                if (!products.Any())
                    return Ok();

                fromCache = JsonSerializer.Serialize(products);
                await _distributedCache.SetStringAsync("GetAllProductByCategory", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<List<Products>>(fromCache);

            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateProduct([FromForm]CreateProductDTO createProductDTO)
        {
                string uniqueFileName = string.Empty;
                if (createProductDTO.Image != null)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + createProductDTO.Image.FileName;
                    string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    createProductDTO.Image.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                }

                CreateProductCommand product = new CreateProductCommand()
                {
                    CategoryName = createProductDTO.CategoryName,
                    ImagePath = "images/" + uniqueFileName,
                    Name = createProductDTO.Name,
                    Price = createProductDTO.Price,
                    Recipe = createProductDTO.Recipe
                };

                var result = await _mediator.Send(product);

                await _distributedCache.RemoveAsync($"Product{product.Name}");
                await _distributedCache.RemoveAsync("GetAllProductByCategory");
                await _distributedCache.RemoveAsync($"GetAllProduct");
                return Ok(result);
         
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateProduct([FromForm]UpdateProductDTO updateProductDTO)
        {
            UpdateProductCommand product = new UpdateProductCommand()
            {
                CategoryName = updateProductDTO.CategoryName,
                Name = updateProductDTO.Name,
                OldName = updateProductDTO.OldName,
                Price = updateProductDTO.Price,
                Recipe = updateProductDTO.Recipe
            };

            string uniqueFileName = string.Empty;
            if (updateProductDTO.Image != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + updateProductDTO.Image.FileName;
                string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                updateProductDTO.Image.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                product.ImagePath = "images/" + uniqueFileName;
            }

            var result = await _mediator.Send(product);

            await _distributedCache.RemoveAsync($"Product{product.Name}");
            await _distributedCache.RemoveAsync("GetAllProductByCategory");
            await _distributedCache.RemoveAsync($"GetAllProduct");

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProduct(string Name)
        {
            var result = await _mediator.Send(new DeleteProductCommand() {Name=Name});

            await _distributedCache.RemoveAsync($"Product{Name}");
            await _distributedCache.RemoveAsync("GetAllProductByCategory");
            await _distributedCache.RemoveAsync($"GetAllProduct");

            return Ok(result);
        }
    }
}

