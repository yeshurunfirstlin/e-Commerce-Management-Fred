using e_Commerce.Application.DTOs.Categories;
using e_Commerce.Application.Features.Categories.Command;
using e_Commerce.Application.Features.Categories.Query;
using MediatR;
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

        [HttpGet("byid-category")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var _category = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(_category);
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest Category)
        {
            var _newCategory = await _mediator.Send(new CreateCategoryCommand(Category));
            return Ok(_newCategory);
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest Category)
        {
            var _upCategory = await _mediator.Send(new UpdateCategoryCommand(Category));
            return Ok(_upCategory);
        }

        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest Category)
        {
            var _delCategory = await _mediator.Send(new DeleteCategoryCommand(Category));
            return Ok(_delCategory);
        }
    }
}
