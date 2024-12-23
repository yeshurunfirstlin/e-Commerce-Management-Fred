using AutoMapper;
using e_Commerce.Application.Features.Products.Command;
using e_Commerce.Application.Features.Products.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            return Ok();
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var _product = await _mediator.Send(command);
            return Ok(command);
        }
    }
}
