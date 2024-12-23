using e_Commerce.Application.DTOs.Categories;
using MediatR;

namespace e_Commerce.Application.Features.Categories.Command;

public record UpdateCategoryCommand (UpdateCategoryRequest UpdateCategory) : IRequest<string>;
