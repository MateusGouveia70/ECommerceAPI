using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string name, string description, int categoriaId, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoriaId = categoriaId;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoriaId { get; set; }
        public Category Category { get; set; }
    }
}


