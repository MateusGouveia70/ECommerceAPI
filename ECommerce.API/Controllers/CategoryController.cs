using ECommerce.Application.InputModels;
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
        private readonly ECommerceDbContext _dbContext;

        public CategoryController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _dbContext.Categories.ToList();

            var categoryViewModel = categories
                .Select(c => new CategoryViewModel(
                    c.Id,
                    c.Name,
                    c.Description))
                .ToList();
                
            return Ok(categoryViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _dbContext.Categories
                .SingleOrDefault(c => c.Id == id);

            if (category == null) return NotFound();

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return Ok(categoryViewModel);
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryInputModel model)
        {
            var category = new Category(
                model.Id,
                model.Name,
                model.Description);

            _dbContext.Categories.Add(category);

            var categoryView = _dbContext.Categories.SingleOrDefault(c => c.Id == model.Id);

            if (categoryView == null) return NotFound();

            var categoryViewModel = new CategoryViewModel(
                categoryView.Id,
                categoryView.Name,
                categoryView.Description);

            
            return Ok(categoryViewModel);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryInputModel model) 
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == model.Id);

            if (category == null) return NotFound();

            category.UpdateCategory(model.Name, model.Description);
            // save

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return Ok(categoryViewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c =>c.Id == id);

            _dbContext.Categories.Remove(category);

            return Ok();
        }
    }
}
