using ECommerce.Application.InputModels;
using ECommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProduct(int id);
        ProductViewModel AddProduct(AddProductInputModel model);
        ProductViewModel UpdateProduct(UpdateProductInputModel model);
        void Delete(int id);
    }
}
