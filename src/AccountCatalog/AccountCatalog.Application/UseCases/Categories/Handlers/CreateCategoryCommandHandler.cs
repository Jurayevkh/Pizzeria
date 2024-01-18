namespace AccountCatalog.Application.UseCases.Categories.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isHaveCategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(category => category.Name == request.Name);

            if (isHaveCategory != null)
                return false;
            await _applicationDbContext.Categories.AddAsync(new Domain.Entities.Category.Categories() {Name=request.Name});
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

