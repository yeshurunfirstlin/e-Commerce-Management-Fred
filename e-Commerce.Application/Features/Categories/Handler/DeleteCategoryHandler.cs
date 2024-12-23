using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.Features.Categories.Command;
using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Handler;

internal class DeleteCategoryHandler(IMapper mapper, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand, string>
{
    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        // Check
        if (request.DeleteCategory.Id <= 0) throw new InvalidDataException("Invalid category id");

        // Is Found
        _ = await categoryRepository.GetByIdAsync(request.DeleteCategory.Id) ?? throw new NotFoundException("Category not found");

        // Delete Category
        var mapModel = mapper.Map<Category>(request.DeleteCategory);
        categoryRepository.Delete(mapModel);
        await unitOfWork.SaveChangesAsync();

        return "Category Deleted Successfully";
    }
}
