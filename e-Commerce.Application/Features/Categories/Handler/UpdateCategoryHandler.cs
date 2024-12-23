using AutoMapper;
using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.Features.Categories.Command;
using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using FluentValidation;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Handler;

internal class UpdateCategoryHandler(IValidator<UpdateCategoryRequest> validator, IMapper mapper, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, string>
{
    public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var _validate = await validator.ValidateAsync(request.UpdateCategory);
        if (_validate.IsValid) throw new ArgumentNullException(string.Join("; ", _validate.Errors.Select(e => e.ErrorMessage)));

        // Is Available
        _ = await categoryRepository.GetByIdAsync(request.UpdateCategory.Id) ?? throw new Exception("Category Not Found");

        // Map Model
        var mapModel = mapper.Map<Category>(request.UpdateCategory);
        categoryRepository.Update(mapModel);
        await unitOfWork.SaveChangesAsync();

        return "Category Updated Successfully";
    }
}
