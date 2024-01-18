namespace AccountCatalog.Application.UseCases.Products.Commands;

public class CreateProductCommand:IRequest<bool>  
{
    public string Name { get; set; }
    public float Price { get; set; }
    public string Recipe { get; set; }
    public string ImagePath { get; set; }
    public string CategoryName { get; set; }
}

