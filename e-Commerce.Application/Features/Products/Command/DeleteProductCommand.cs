using MediatR;

namespace e_Commerce.Application.Features.Products.Command;

public record DeleteProductCommand(int id) : IRequest<string>;
