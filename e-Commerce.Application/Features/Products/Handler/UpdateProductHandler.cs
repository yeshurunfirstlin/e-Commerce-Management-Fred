using AutoMapper;
using e_Commerce.Application.DTOs.Products;
using e_Commerce.Application.Features.Products.Command;
using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using FluentValidation;
using MediatR;

namespace e_Commerce.Application.Features.Products.Handler;

internal class UpdateProductHandler(IValidator<UpdateProductRequest> validator, IMapper mapper, IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, string>
{
    public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var _validate = await validator.ValidateAsync(request.UpdateProduct);
        if (!_validate.IsValid) throw new ArgumentNullException(string.Join("; ", _validate.Errors.Select(e => e.ErrorMessage)));

        // Is Product Found?
        _ = await productRepository.GetByIdAsync(request.UpdateProduct.Id) ?? throw new Exception("Product Not Found");

        // Map Model
        var mapModel = mapper.Map<Product>(request.UpdateProduct);
        productRepository.Update(mapModel);
        await unitOfWork.SaveChangesAsync();

        return "Product Updated Successfully";
    }
}
