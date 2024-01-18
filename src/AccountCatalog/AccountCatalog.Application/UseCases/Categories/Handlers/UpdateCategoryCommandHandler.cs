namespace AccountCatalog.Application.UseCases.Categories.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(category=>category.Name==request.OldName);
            if (category is null)
                return false;
            category.Name = request.NewName;
            _applicationDbContext.Categories.Update(category);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

