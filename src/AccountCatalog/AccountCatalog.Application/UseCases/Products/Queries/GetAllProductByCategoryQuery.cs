namespace AccountCatalog.Application.UseCases.Products.Queries;
using AccountCatalog.Domain.Entities.Product;

public class GetAllProductByCategoryQuery:IRequest<List<Products>>
{
    public string CategoryName { get; set; }
}

