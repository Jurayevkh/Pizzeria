namespace AccountCatalog.Application.UseCases.Categories.Handlers;
using AccountCatalog.Domain.Entities.Category;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCustomers, List<Categories>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllCategoryQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Categories>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
    {
        var categories = await _applicationDbContext.Categories.ToListAsync();
        return categories;
    }
}

