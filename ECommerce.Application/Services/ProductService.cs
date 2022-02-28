using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
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
        private readonly ECommerceDbContext _dbContext;

        public ProductService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductViewModel> GetAllProducts()
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

            return productViewModel;
        }

        public ProductViewModel GetProduct(int id)
        {
            var productAndCategory = _dbContext.Products
                .Include(p => p.Category)
                .SingleOrDefault(p => p.Id == id);


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

        public ProductViewModel AddProduct(AddProductInputModel model)
        {
            var product = new Product(
                model.Name,
                model.Description,
                model.Value,
                model.Brand,
                model.Category_Id);

            var category = _dbContext.Categories.SingleOrDefault(c => product.Category_Id == c.Id);

            if (category != null)
            {
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

                return productViewModel;
            }

            return null;
           
        }

        public ProductViewModel UpdateProduct(UpdateProductInputModel model)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == model.Id);

            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == model.Category_Id);


            if (product != null && category != null)
            {
                product.UpdateProduct(model.Name, model.Description, model.Value, model.Brand, model.Category_Id);
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

                return productViewModel;

            }

            return null;
            
        }

        public void Delete(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
