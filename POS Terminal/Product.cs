using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Terminal
{
    public enum CategoryList
    {
        Food,
        Drink,
        Dessert
    }

    public class Product
    {
        public string Name { get; set; }
        public CategoryList Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string name, CategoryList category, string description, double price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        } 

        public override string ToString()
        {
            return String.Format("{0,-36}{1, 6}", $"{Name}", $"{Price}");
        }
    }
}
