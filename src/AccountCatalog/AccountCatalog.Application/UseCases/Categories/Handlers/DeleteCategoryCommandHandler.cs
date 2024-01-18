namespace AccountCatalog.Application.UseCases.Categories.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteCategoryCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try{
            var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(category=>category.Name==request.Name);
            if (category is null)
                return false;
            _applicationDbContext.Categories.Remove(category);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

