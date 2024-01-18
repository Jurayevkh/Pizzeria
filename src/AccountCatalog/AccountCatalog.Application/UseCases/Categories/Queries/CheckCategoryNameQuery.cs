namespace AccountCatalog.Application.UseCases.Categories.Queries;

public class CheckCategoryNameQuery:IRequest<bool>
{
    public string Name { get; set; }
}

