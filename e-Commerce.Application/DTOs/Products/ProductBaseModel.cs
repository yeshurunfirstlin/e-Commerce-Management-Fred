namespace e_Commerce.Application.DTOs.Products;

public class ProductBaseModel
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}