using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository; 
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var productAndCategory = await _productRepository.GetAllAsync();


            var productViewModel = productAndCategory.Select(p => new ProductViewModel(
                p.Id,
                p.Name,
                p.Description,
                p.Category_Id,
                p.Category.Id,
                p.Category.Name,
                p.Category.Description)).ToList();
               

            return productViewModel;
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            var productAndCategory = await _productRepository.GetByIdAsync(id);


            if (productAndCategory != null)
            {
                var productViewModel = new ProductViewModel(
                productAndCategory.Id,
                productAndCategory.Name,
                productAndCategory.Description,
                productAndCategory.Category_Id,
                productAndCategory.Category.Id,
                productAndCategory.Category.Name,
                productAndCategory.Category.Description);

                return productViewModel;
            }
            
            return null;
        }

        public async Task<ProductViewModel> AddProduct(AddProductInputModel model)
        {
            var product = new Product(
                model.Name,
                model.Description,
                model.Value,
                model.Brand,
                model.Category_Id);

            var category = _categoryRepository.GetByIdAsync(product.Category_Id);

            if (category != null)
            {
                await _productRepository.AddProductAsync(product);


                var productAndCategory = await _productRepository.GetByIdAsync(product.Id);

                var productViewModel = new ProductViewModel(
                    productAndCategory.Id,
                    productAndCategory.Name,
                    productAndCategory.Description,
                    productAndCategory.Category_Id,
                    productAndCategory.Category.Id,
                    productAndCategory.Category.Name,
                    productAndCategory.Category.Description);

                return  productViewModel;
            }

            return null;
           
        }

        public async Task<ProductViewModel> UpdateProduct(UpdateProductInputModel model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);

            var category = await _categoryRepository.GetByIdAsync(model.Category_Id);


            if (product != null && category != null)
            {
                product.UpdateProduct(model.Name, model.Description, model.Value, model.Brand, model.Category_Id);

                await _productRepository.SaveChangesAsync();

                var productAndCategory = await _productRepository.GetByIdAsync(product.Id);

                var productViewModel = new ProductViewModel(
                    productAndCategory.Id,
                    productAndCategory.Name,
                    productAndCategory.Description,
                    productAndCategory.Category_Id,
                    productAndCategory.Category.Id,
                    productAndCategory.Category.Name,
                    productAndCategory.Category.Description);

                return productViewModel;

            }

            return null;
            
        }

        public async Task Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
