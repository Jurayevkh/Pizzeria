﻿namespace AccountCatalog.API.DTO.Products;

public class CreateProductDTO
{
    public string Name { get; set; }
    public float Price { get; set; }
    public string Recipe { get; set; }
    public IFormFile Image { get; set; }
    public string CategoryName { get; set; }
}

