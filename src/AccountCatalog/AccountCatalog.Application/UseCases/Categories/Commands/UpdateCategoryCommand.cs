namespace AccountCatalog.Application.UseCases.Categories.Commands;

public class UpdateCategoryCommand:IRequest<bool>
{
    public string OldName { get; set; }
    public string NewName { get; set; }
}

