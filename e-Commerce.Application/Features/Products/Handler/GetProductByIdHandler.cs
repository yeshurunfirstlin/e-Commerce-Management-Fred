using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.DTOs.Products;
using e_Commerce.Application.Features.Products.Query;
using e_Commerce.Domain.Contracts;
using MediatR;

namespace e_Commerce.Application.Features.Products.Handler;

internal class GetProductByIdHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, GetProduct>
{
    public async Task<GetProduct> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        // Is Product?
        var _product = await productRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Product Not Found");

        // Map Model
        var mapModel = mapper.Map<GetProduct>(_product);

        return mapModel;
    }
}
