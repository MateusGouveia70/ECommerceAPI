using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;

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
        public IActionResult GetAll()
        {
            var productViewModel = _productService.GetAllProducts();

            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productAndCategory = _productService.GetProduct(id);

            if (productAndCategory == null) return NotFound();

            return Ok(productAndCategory);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductInputModel model)
        {
            var productViewModel = _productService.AddProduct(model);

            if (productViewModel == null) return BadRequest($"A categoria do produto não está cadastrada no sistema");
          
            return Ok(productViewModel);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductInputModel model)
        {
           var productViewModel = _productService.UpdateProduct(model);

            if (productViewModel == null) return BadRequest($"Não tem o msm Id ou Não possui a categoria");

            return Ok(productViewModel); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok();

                throw new Exception();
            }
            catch (Exception)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
