using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskThree
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public Product(string productName, string productCategory)
        {
            this.ProductName = productName;
            this.ProductCategory = productCategory;
        }
    }
}
