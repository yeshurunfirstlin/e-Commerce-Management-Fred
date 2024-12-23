using e_Commerce.Application.Features.Products.Command;
using e_Commerce.Domain.Contracts;
using MediatR;

namespace e_Commerce.Application.Features.Products.Handler;

internal class DeleteProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, string>
{
    public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // validate
        if (request.id <= 0) throw new InvalidDataException("Product Not Found");

        // Is Found
        _ = await productRepository.GetByIdAsync(request.id);

        // Delete
        await productRepository.DeleteAsync(request.id);
        await unitOfWork.SaveChangesAsync();

        return "Product Deleted Successfully";
    }
}
