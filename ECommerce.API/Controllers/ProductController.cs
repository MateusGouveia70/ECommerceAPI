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
            var products = _dbContext.Products.ToList();

            var productViewModel = products.Select(p => new ProductViewModel( 
                p.Id,
                p.Name,
                p.Description,
                p.Category_Id,
                p.Category.Id,
                p.Category.Name,
                p.Category.Description)).ToList();

            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            var productViewModel = new ProductViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.Category_Id,
                product.Category.Id,
                product.Category.Name,
                product.Category.Description);

            return Ok(productViewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductInputModel model)
        {
            var product = new Product(
                model.Id,
                model.Name,
                model.Description,
                model.Value,
                model.Brand,
                model.Category_Id);

            _dbContext.Products.Add(product);

            var productView = _dbContext.Products.SingleOrDefault(p => p.Id == product.Id);

            if (productView == null) return NotFound();

            var productViewModel = new ProductViewModel(
                productView.Id,
                productView.Name,
                product.Description,
                product.Category_Id,
                product.Category.Id,
                product.Category.Name,
                product.Category.Description);
          
            return Ok(productView);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductInputModel model)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == model.Id);

            if(product == null) return NotFound();

            product.UpdateProduct(model.Id, model.Name, model.Description, model.Value, model.Brand, model.Category_Id);
            // save

            var productViewModel = new ProductViewModel(
                product.Id,
                product.Name,
                product.Description,
                product.Category_Id,
                product.Category.Id,
                product.Category.Name,
                product.Category.Description);

            return Ok(productViewModel); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            _dbContext.Products.Remove(product);
            //save

            return Ok();
        }
    }
}
