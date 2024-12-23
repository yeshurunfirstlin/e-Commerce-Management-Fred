using AutoMapper;
using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.DTOs.Products;
using e_Commerce.Domain.Entities;

namespace e_Commerce.Application.Common.AutoMapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<DeleteCategoryRequest, Category>();
        CreateMap<Category, GetCategory>();

        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<Product, GetProduct>();
    }
}
