using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.Features.Categories.Query;
using e_Commerce.Domain.Contracts;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Handler;

internal class GetCategoryByIdHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQuery, GetCategory>
{
    public async Task<GetCategory> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // Is Category?
        var _category = await categoryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Category Not Found");

        // Map Model
        var mapModel = mapper.Map<GetCategory>(_category);

        return mapModel;
    }
}