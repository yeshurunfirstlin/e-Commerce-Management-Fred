using e_Commerce.Application.DTOs.Products;
using FluentValidation;

namespace e_Commerce.Application.Features.Categories.Validation;

public class CreateCategoryValidator : AbstractValidator<CreateProductRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(category => category.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
    }
}