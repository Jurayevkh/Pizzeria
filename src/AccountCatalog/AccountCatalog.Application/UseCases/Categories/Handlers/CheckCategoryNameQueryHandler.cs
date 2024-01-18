namespace AccountCatalog.Application.UseCases.Categories.Handlers;

public class CheckCategoryNameQueryHandler : IRequestHandler<CheckCategoryNameQuery, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CheckCategoryNameQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CheckCategoryNameQuery request, CancellationToken cancellationToken)
    {
        var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(category=>category.Name==request.Name);
        if (category is null)
            return false;
        return true;
    }
}


