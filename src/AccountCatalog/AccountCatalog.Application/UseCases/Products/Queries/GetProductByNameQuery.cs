namespace AccountCatalog.Application.UseCases.Products.Queries;
using AccountCatalog.Domain.Entities.Product;


public class GetProductByNameQuery:IRequest<Products>
{
    public string Name { get; set; }
}

