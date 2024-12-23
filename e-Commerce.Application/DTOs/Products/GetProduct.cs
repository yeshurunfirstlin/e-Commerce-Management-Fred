using e_Commerce.Application.DTOs.Categories;

namespace e_Commerce.Application.DTOs.Products;

public class GetProduct : ProductBaseModel
{
    public int Id { get; set; }
    public GetCategory Category { get; set; } = null!;
}