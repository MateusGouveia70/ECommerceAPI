using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public string Brand { get; private set; }
        public int Category_Id { get; private set; }
        public Category Category { get; private set; }

        public Product(int id, string name, decimal value, string brand, int category_Id)
        {
            Id = id;
            Name = name;
            Value = value;
            Brand = brand;
            Category_Id = category_Id;
        }
    }
} 

