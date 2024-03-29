﻿namespace AccountCatalog.Application.UseCases.Products.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IApplicationDbContext _applicationdDbContext;

    public UpdateProductCommandHandler(IApplicationDbContext applicationdDbContext)
    {
        _applicationdDbContext = applicationdDbContext;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _applicationdDbContext.Products.FirstOrDefaultAsync(product=>product.Name==request.OldName);
            if (product is null)
                return false;
            product.Name = request.Name ?? product.Name;
            product.Price = request.Price ?? product.Price;
            product.Recipe = request.Recipe ?? product.Recipe;
            if(request.ImagePath is not null){
                string wwwRootPath = "/Users/mac/Desktop/Pizzeria/src/AccountCatalog/AccountCatalog.API/wwwroot";
                string imagesFolderPath = Path.Combine(wwwRootPath, product.ImagePath);
                File.Delete(imagesFolderPath);
                product.ImagePath = request.ImagePath;
            }
            product.UpdatedAt = DateTime.UtcNow;
            _applicationdDbContext.Products.Update(product);
            var result = await _applicationdDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
           return false;
        }
    }
}

