using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.Features.Categories.Command;
using e_Commerce.Application.Features.Categories.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Commerce.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) => _mediator = mediator;

        [HttpGet("all-category")]
        public async Task<IActionResult> GetAll()
        {
            var _categories = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(_categories);
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest Category)
        {
            var _category = await _mediator.Send(new CreateCategoryCommand(Category));
            return Ok(_category);
        }

    }
}
