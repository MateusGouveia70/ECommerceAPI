using ECommerce.Application.InputModels;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Application.ViewModels;
using ECommerce.Core.Entities;
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
        private readonly ECommerceDbContext _dbContext;

        public CategoryService(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryViewModel> GetAllCategory()
        {
            var categories = _dbContext.Categories.ToList();

            var categoryViewModel = categories
                .Select(c => new CategoryViewModel(
                    c.Id,
                    c.Name,
                    c.Description))
                .ToList();

            return categoryViewModel;
        }

        public CategoryViewModel GetCategory(int id)
        {
            var category = _dbContext.Categories
                .SingleOrDefault(c => c.Id == id);

            if (category == null) return null;

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return categoryViewModel;
        }

        public CategoryViewModel AddCategoy(AddCategoryInputModel model)
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

            return categoryViewModel;
        }

        public CategoryViewModel UpdateCategory(UpdateCategoryInputModel model)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == model.Id);

            if (category == null) return null;

            category.UpdateCategory(model.Name, model.Description);
            _dbContext.SaveChanges();

            var categoryViewModel = new CategoryViewModel(
                category.Id,
                category.Name,
                category.Description);

            return categoryViewModel;
        }

        public bool DeleteCategory(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(c => c.Id == id);

            var product = _dbContext.Products.FirstOrDefault(p => p.Category_Id == id);

            if (category == null || product != null) return false;

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return true;

        }
    }
}
