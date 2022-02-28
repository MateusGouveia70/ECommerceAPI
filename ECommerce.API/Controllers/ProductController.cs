using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productViewModel = await _productService.GetAllProducts();

            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productAndCategory = await _productService.GetProduct(id);

            if (productAndCategory == null) return NotFound();

            return Ok(productAndCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductInputModel model)
        {
            var productViewModel = await _productService.AddProduct(model);

            if (productViewModel == null) return BadRequest($"A categoria do produto não está cadastrada no sistema");
          
            return Ok(productViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductInputModel model)
        {
           var productViewModel = await _productService.UpdateProduct(model);

            if (productViewModel == null) return BadRequest($"O produto de Id {model.Id} não está cadastrado ou a categoria informada não existe");

            return Ok(productViewModel); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);

            return Ok();
        }
    }
}

