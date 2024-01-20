namespace AccountCatalog.Application.UseCases.Products.Handlers;
using AccountCatalog.Domain.Entities.Product;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateProductCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isHaveProduct = await _applicationDbContext.Products.FirstOrDefaultAsync(product=>product.Name==request.Name);
            if (isHaveProduct != null)
                return false;
            var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(category=>category.Name==request.CategoryName);
            Products product = new Products()
            {
                Name = request.Name,
                Price = request.Price,
                Recipe = request.Recipe,
                ImagePath = request.ImagePath,
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow
            };
            await _applicationDbContext.Products.AddAsync(product);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

