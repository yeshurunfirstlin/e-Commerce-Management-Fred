using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.Features.Categories.Command;
using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using FluentValidation;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Handler;

internal class CreateCategoryHandler(
    IValidator<CreateCategoryRequest> validator, ICategoryRepository categoryRepository,
    IMapper mapper, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateCategoryCommand, string>
{
    public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate Input
        var _validate = await validator.ValidateAsync(request.Category);
        if (!_validate.IsValid) throw new ArgumentNullException(string.Join("; ", _validate.Errors.Select(e => e.ErrorMessage)));

        // Is Available
        bool isAvailable = await categoryRepository.IsAvailableByNameAsync(request.Category.Name!);
        if (isAvailable) throw new AlreadyExistException("Category already added");

        // Mapping
        var mapModel = mapper.Map<Category>(request.Category);
        categoryRepository.Add(mapModel);
        await unitOfWork.SaveChangesAsync();

        return "Category Added Successfully";
    }
}