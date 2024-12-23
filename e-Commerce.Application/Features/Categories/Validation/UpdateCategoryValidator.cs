using e_Commerce.Application.DTOs.Categories;
using FluentValidation;

namespace e_Commerce.Application.Features.Categories.Validation;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(category => category.Id)
                .GreaterThan(0).WithMessage("Id must be a positive number.");

        RuleFor(category => category.Name)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");        
    }
}