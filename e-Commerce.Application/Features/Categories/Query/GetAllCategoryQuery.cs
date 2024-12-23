using e_Commerce.Application.DTOs.Categories;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Query;

public record GetAllCategoryQuery : IRequest<IEnumerable<GetCategory>>;