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
        public ProductViewModel(int id, string name, string description, int categoria_Id, int categoriaId, 
            string categoyName, string categoryDescription)
        {
            Id = id;
            Name = name;
            Description = description;
            Categoria_Id = categoria_Id;
            CategoriaId = categoriaId;
            CategoryName = categoyName;
            CategoryDescription = categoryDescription;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Categoria_Id{ get; set; }
        public int CategoriaId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}


