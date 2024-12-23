using e_Commerce.Application.DTOs.Products;
using MediatR;

namespace e_Commerce.Application.Features.Products.Query;

public record GetProductByIdQuery(int Id) : IRequest<GetProduct>;