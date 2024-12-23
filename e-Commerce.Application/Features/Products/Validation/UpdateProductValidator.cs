using e_Commerce.Application.DTOs.Products;
using FluentValidation;

namespace e_Commerce.Application.Features.Products.Validation;

public class UpdateProductValidator : ProductBaseValidator<UpdateProductRequest>
{
    public UpdateProductValidator() 
    {
        RuleFor(product => product.Id)
            .GreaterThan(0).WithMessage("Id must be a positive number.");
    }
}
