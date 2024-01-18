namespace AccountCatalog.API.DTO.Products;

public class UpdateProductDTO
{
    public string OldName { get; set; }
    public string? Name { get; set; }
    public float? Price { get; set; }
    public string? Recipe { get; set; }
    public string? ImagePath { get; set; }
    public string? CategoryName { get; set; }
}

