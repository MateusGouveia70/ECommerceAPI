using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        { 
            var categories = await _categoryRepository.GetAllAsync();

            var categoryViewModel = categories
                .Select(c => new CategoryViewModel(
                    c.Id,
                    c.Name,
                    c.Description))
                .ToList();

            return categoryViewModel;
        }

        public async Task<CategoryViewModel> GetCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null) return null;

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return categoryViewModel;
        }

        public async Task<CategoryViewModel> AddCategoy(AddCategoryInputModel model)
        {
            var category = new Category(
                model.Name,
                model.Description);

            await _categoryRepository.AddCategoryAsync(category);

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return categoryViewModel;
        }

        public async Task<CategoryViewModel> UpdateCategoyAsync(UpdateCategoryInputModel model) 
        {
            var category = await _categoryRepository.GetByIdAsync(model.Id); 

            if (category == null) return null;

            category.UpdateCategory(model.Name, model.Description);
            
            await _categoryRepository.SaveChangesAsync();

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return categoryViewModel;
        } 

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            var product = await _productRepository.GetByIdAsync(category.Id);

            // product.Category.Id = category.Id;


            if (category == null || product != null) return false;

            
            return true;

        }
    }
}
