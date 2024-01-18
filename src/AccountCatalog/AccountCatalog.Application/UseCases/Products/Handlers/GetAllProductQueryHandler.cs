namespace AccountCatalog.Application.UseCases.Products.Handlers;
using AccountCatalog.Domain.Entities.Product;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Products>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllProductQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Products>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Products.ToListAsync();
    }
}

