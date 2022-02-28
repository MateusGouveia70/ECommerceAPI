using ECommerce.Application.InputModels;
using ECommerce.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategory();
        Task<CategoryViewModel> GetCategory(int id);
        Task<CategoryViewModel> AddCategoy(AddCategoryInputModel model);
        Task<CategoryViewModel> UpdateCategoyAsync(UpdateCategoryInputModel model);
        Task<bool> DeleteCategory(int id);
      
    }
}
