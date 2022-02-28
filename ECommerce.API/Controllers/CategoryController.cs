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
                model.Name,
                model.Description);

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            
            return Ok(categoryViewModel);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryInputModel model) 
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == model.Id);

            if (category == null) return NotFound();

            category.UpdateCategory(model.Name, model.Description);
            _dbContext.SaveChanges();

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

            if (category == null) return NotFound();

            var product = _dbContext.Products.FirstOrDefault(p => p.Category_Id == id);

            if (product != null) return BadRequest("A categoria não poderá ser deletada se tiver relacionada com um produto.");

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
