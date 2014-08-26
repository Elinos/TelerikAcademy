using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskFour
{
    class Product
    {
        public Product(string name, int supplierID, int categoryID, string quantityPerUnit, decimal price, int unitsInStock, int unitsOnOrder, int reorderLevel, int discontinued)
        {
            this.Name = name;
            this.SupplierID = supplierID;
            this.CategoryID = categoryID;
            this.QuantityPerUnit = quantityPerUnit;
            this.Price = price;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.ReorderLevel = reorderLevel;
            this.Discontinued = discontinued;
        }

        public string Name { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public int Discontinued { get; set; }
    }
}
