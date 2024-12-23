using e_Commerce.Application.DTOs.Products;
using MediatR;

namespace e_Commerce.Application.Features.Products.Command;

public record CreateProductCommand(CreateProductRequest Product) : IRequest<string>;