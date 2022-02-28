using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllCategory();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryViewModel = await _categoryService.GetCategory(id);

            if (categoryViewModel == null) return NotFound();

            return Ok(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryInputModel model)
        {
            var categoryViewModel = await _categoryService.AddCategoy(model);

            return Ok(categoryViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryInputModel model) 
        {
            var categoryViewModel = await _categoryService.UpdateCategoyAsync(model);

            if (categoryViewModel == null) return NotFound();

            return Ok(categoryViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var delete = await _categoryService.DeleteCategory(id);

            if (!delete) return BadRequest("Categoria não se encontra ou tem um produto cadastrado com essse Id");

            return Ok();
        }
    }
}
