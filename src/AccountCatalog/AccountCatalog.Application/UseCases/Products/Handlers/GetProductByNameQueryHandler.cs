namespace AccountCatalog.Application.UseCases.Products.Handlers;
using AccountCatalog.Domain.Entities.Product;


public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, Products>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetProductByNameQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Products> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Products.FirstOrDefaultAsync(product=>product.Name==request.Name);
    }
}

