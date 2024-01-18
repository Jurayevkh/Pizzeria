namespace AccountCatalog.Application.UseCases.Products.Handlers;
using AccountCatalog.Domain.Entities.Product;

public class GetAllProductByCategoryQueryHandler : IRequestHandler<GetAllProductByCategoryQuery, List<Products>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllProductByCategoryQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Products>> Handle(GetAllProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(category=>category.Name==request.CategoryName);
        return await _applicationDbContext.Products.Where(product => product.CategoryId == category.Id).ToListAsync();
    }
}

