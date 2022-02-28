using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Persistence
{
    public class ECommerceDbContext
    {
        public ECommerceDbContext()
        {
            Categories = new List<Category>()
            { new Category(1, "Moda", "Categoria de Moda"),
              new Category(2, "Automotivos", "Categoria de Automotivos"),
              new Category(3, "Tecnologia", "Categoria de Tecnologia")
            };

            Products = new List<Product>()
            {
                new Product(1, "Notbook","Notook Muito rápido", 3000, "Accer", 3),
                new Product(2, "Celular","Celular da hora" ,2850,"Motorolla", 3),
                new Product(3, "Camisa Polo", "Camisa muito bonita", 350, "Polo", 1)
            };
        }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
