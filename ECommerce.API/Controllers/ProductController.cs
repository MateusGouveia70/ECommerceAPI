using ECommerce.Application.InputModels;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase   // falta o include
    {
        private readonly ECommerceDbContext _dbContext;

        public ProductController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productAndCategory = _dbContext.Products.Include(p => p.Category).Select(p => new ProductViewModel(
                p.Id,
                p.Name,
                p.Description,
                p.Category_Id,
                p.Category.Id,
                p.Category.Name,
                p.Category.Description)).ToList();

            var productViewModel = productAndCategory.Select(p => new ProductViewModel(
                p.Id,
                p.Name,
                p.Description,
                p.Categoria_Id,
                p.CategoriaId,
                p.CategoryName,
                p.CategoryDescription)).ToList();

            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productAndCategory = _dbContext.Products
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == id);

            if (productAndCategory == null) return NotFound();

            var productViewModel = new ProductViewModel(
                productAndCategory.Id,
                productAndCategory.Name,
                productAndCategory.Description,
                productAndCategory.Category_Id,
                productAndCategory.Category.Id,
                productAndCategory.Category.Name,
                productAndCategory.Category.Description);

            return Ok(productViewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductInputModel model)
        {
            var product = new Product(
                model.Name,
                model.Description,
                model.Value,
                model.Brand,
                model.Category_Id);

            var category = _dbContext.Categories.SingleOrDefault(c => product.Category_Id == c.Id);

            if (category == null) return BadRequest($"A categoria de Id : {product.Category_Id} não está cadastrada no sistema");


            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            
            var productAndCategory = _dbContext.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == product.Id);

            var productViewModel = new ProductViewModel(
                productAndCategory.Id,
                productAndCategory.Name,
                productAndCategory.Description,
                productAndCategory.Category_Id,
                productAndCategory.Category.Id,
                productAndCategory.Category.Name,
                productAndCategory.Category.Description);
          
            return Ok(productViewModel);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductInputModel model)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == model.Id);

            if(product == null) return NotFound();

            product.UpdateProduct(model.Id, model.Name, model.Description, model.Value, model.Brand, model.Category_Id);

            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == product.Category_Id);

            if (category == null) return BadRequest($"A categoria de Id: {product.Category_Id} não está cadastrada no sistema");

            _dbContext.SaveChanges();

            var productAndCategory = _dbContext.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == product.Id);

            var productViewModel = new ProductViewModel(
                productAndCategory.Id,
                productAndCategory.Name,
                productAndCategory.Description,
                productAndCategory.Category_Id,
                productAndCategory.Category.Id,
                productAndCategory.Category.Name,
                productAndCategory.Category.Description);

            return Ok(productViewModel); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
