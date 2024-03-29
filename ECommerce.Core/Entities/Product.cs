﻿namespace ECommerce.Core.Entities
{
    public class Product
    {
        public Product(string name, string description, decimal value, string brand, int category_Id)
        {
            Name = name;
            Description = description;
            Value = value;
            Brand = brand;
            Category_Id = category_Id;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public string Brand { get; private set; }
        public int Category_Id { get; private set; }
        public Category Category { get; private set; }


        public void UpdateProduct(string name, string description, decimal value, string brand, int category_Id)
        {
            Name = name;
            Description = description;
            Value = value;
            Brand = brand;
            Category_Id = category_Id;
        }
    }
}

