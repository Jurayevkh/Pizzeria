namespace AccountCatalog.Application.UseCases.Categories.Commands;

public class DeleteCategoryCommand:IRequest<bool>
{
    public string Name { get; set; }
}

