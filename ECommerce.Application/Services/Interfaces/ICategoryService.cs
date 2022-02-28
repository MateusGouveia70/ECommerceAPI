using ECommerce.Application.InputModels;
using ECommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAllCategory();
        CategoryViewModel GetCategory(int id);
        CategoryViewModel AddCategoy(AddCategoryInputModel model);
        CategoryViewModel UpdateCategory(UpdateCategoryInputModel model);
        bool DeleteCategory(int id);
      
    }
}
