using AutoMapper;
using e_Commerce.Application.Common.Exceptions;
using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.Features.Categories.Query;
using e_Commerce.Domain.Contracts;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Handler;

internal class GetAllCategoryHandler(IMapper mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoryQuery, IEnumerable<GetCategory>>
{
    public async Task<IEnumerable<GetCategory>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        // Is Category?
        var _categories = await categoryRepository.GetAllAsync() ?? throw new NotFoundException("Category Not Found");

        //Map Model
        var mapModel = mapper.Map<IEnumerable<GetCategory>>(_categories);

        return mapModel;
    }
}