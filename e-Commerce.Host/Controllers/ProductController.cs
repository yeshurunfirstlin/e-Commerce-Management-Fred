using e_Commerce.Application.DTOs.Products;
using e_Commerce.Application.Features.Products.Command;
using e_Commerce.Application.Features.Products.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Commerce.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet("all-product")]
        public async Task<IActionResult> GetAll()
        {
            var _products = await _mediator.Send(new GetAllProductQuery());
            return Ok(_products);
        }

        [HttpGet("byid-product")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var _product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(_product);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest Product)
        {
            var _newProduct = await _mediator.Send(new CreateProductCommand(Product));
            return Ok(_newProduct);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest Product)
        {
            var _upProduct = await _mediator.Send(new UpdateProductCommand(Product));
            return Ok(_upProduct);
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var _delProduct = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(_delProduct);
        }
    }
}
