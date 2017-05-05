using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Application.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Categories : List<Category>
    {
        public ICollection<Category> listCategory { get; set; }

        public Categories()
        {
            Add(new Category() { CategoryId = 1, CategoryName = "C1" });
            Add(new Category() { CategoryId = 2, CategoryName = "C2" });
            Add(new Category() { CategoryId = 3, CategoryName = "C3" });
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
    }

    public class Products : List<Product>
    {
        public Products()
        {
            Add(new Product() { ProductId = 1, ProductName = "C1", CategoryId = 1 });
            Add(new Product() { ProductId = 2, ProductName = "C2", CategoryId = 1 });
            Add(new Product() { ProductId = 3, ProductName = "C3", CategoryId = 3 });
            Add(new Product() { ProductId = 4, ProductName = "C3", CategoryId = 2 });
        }
    }
}