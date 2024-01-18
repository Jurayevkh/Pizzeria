namespace AccountCatalog.Application.UseCases.Products.Commands;

public class DeleteProductCommand:IRequest<bool>
{
    public string Name { get; set; }
}

