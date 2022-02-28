using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Category
    {
        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;

            Products = new List<Product>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Product> Products { get; private set; }


        public void UpdateCategory(string name, string description)
        {
            Name = name;
            Description=description;
        }
    }
}
