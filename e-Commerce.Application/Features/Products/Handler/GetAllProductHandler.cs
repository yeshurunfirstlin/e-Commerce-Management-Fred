using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.DTOs.Products;
using e_Commerce.Application.Features.Products.Query;
using e_Commerce.Domain.Contracts;
using MediatR;

namespace e_Commerce.Application.Features.Products.Handler;

internal class GetAllProductHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetAllProductQuery, IEnumerable<GetProduct>>
{
    public async Task<IEnumerable<GetProduct>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        // Is product?
        var _products = await productRepository.GetAllAsync() ?? throw new NotFoundException("Product Not Found");

        // Map Model
        var mapModel = mapper.Map<IEnumerable<GetProduct>>(_products);

        return mapModel;
    }
}
