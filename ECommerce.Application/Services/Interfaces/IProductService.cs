using ECommerce.Application.InputModels;
using ECommerce.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> GetProduct(int id);
        Task<ProductViewModel> AddProduct(AddProductInputModel model);
        Task<ProductViewModel> UpdateProduct(UpdateProductInputModel model);
        Task Delete(int id);
    }
}
