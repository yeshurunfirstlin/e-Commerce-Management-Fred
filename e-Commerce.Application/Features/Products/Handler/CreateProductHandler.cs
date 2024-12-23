using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.DTOs.Products;
using e_Commerce.Application.Features.Products.Command;
using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using FluentValidation;
using MediatR;

namespace e_Commerce.Application.Features.Products.Handler;

internal class CreateProductHandler(
    IValidator<CreateProductRequest> validator, IProductRepository productRepository,
    IMapper mapper, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateProductCommand, string>
{
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate Input
        var _validate = await validator.ValidateAsync(request.Product);
        if (!_validate.IsValid) throw new ArgumentNullException(string.Join("; ", _validate.Errors.Select(e => e.ErrorMessage)));

        // To Check product is available or not
        bool isAvailable = await productRepository.IsAvailableByNameAsync(request.Product.Name!);
        if (isAvailable) throw new AlreadyExistException("Product already added");

        // Mapping the product CreateProductRequest to entity Product
        var mapModel = mapper.Map<Product>(request.Product);
        productRepository.Add(mapModel);
        await unitOfWork.SaveChangesAsync();

        return "Product Added Successfully";
    }
}