namespace AccountCatalog.Application.UseCases.Products.Handlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IApplicationDbContext _applicationdDbContext;

    public DeleteProductCommandHandler(IApplicationDbContext applicationdDbContext)
    {
        _applicationdDbContext = applicationdDbContext;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _applicationdDbContext.Products.FirstOrDefaultAsync(product=>product.Name==request.Name);
            if (product is null)
                return false;
            _applicationdDbContext.Products.Remove(product);
            var result = await _applicationdDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

