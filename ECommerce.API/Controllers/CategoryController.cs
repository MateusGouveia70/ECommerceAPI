using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult GetAll()
        {
            var category = _categoryService.GetAllCategory();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoryViewModel = _categoryService.GetCategory(id);

            if (categoryViewModel == null) return NotFound();

            return Ok(categoryViewModel);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryInputModel model)
        {
            var categoryViewModel = _categoryService.AddCategoy(model);

            return Ok(categoryViewModel);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryInputModel model) 
        {
            var categoryViewModel = _categoryService.UpdateCategory(model);

            if (categoryViewModel == null) return NotFound();

            return Ok(categoryViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var delete = _categoryService.DeleteCategory(id);

            if(delete == false) return BadRequest("A categoria não poderá ser deletada se tiver relacionada com um produto.");

            return Ok();
        }
    }
}
