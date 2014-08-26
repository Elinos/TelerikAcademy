using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace TaskFour
{
    class TaskFour
    {
        private static SqlConnection dbCon;

        private static void ConnectToDB()
        {
            ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbCon = new SqlConnection(dBConnectionString.ConnectionString);
            dbCon.Open();
        }

        private static void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        public static void Main()
        {
            try
            {
                ConnectToDB();
                Product product = new Product("Smood", 2, 1, "10 - 1l bottles", 20.00m, 100, 0, 10, 0);
                try
                {
                    AddProduct(product);
                    Console.WriteLine("Product {0} added!", product.Name);
                }
                catch(SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            finally
            {
                DisconnectFromDB();
            }
        } 

        private static void AddProduct(Product product)
        {
            string columns = "ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued";
            string values = "@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued";
            string commandText = "INSERT INTO Products (" + columns + ") VALUES (" + values + ")";
            SqlCommand addProductCommand = new SqlCommand(commandText, dbCon);
            addProductCommand.Parameters.AddWithValue("@productName", product.Name);
            addProductCommand.Parameters.AddWithValue("@supplierID", product.SupplierID);
            addProductCommand.Parameters.AddWithValue("@categoryID", product.CategoryID);
            addProductCommand.Parameters.AddWithValue("@quantityPerUnit", product.QuantityPerUnit);
            addProductCommand.Parameters.AddWithValue("@unitPrice", product.Price);
            addProductCommand.Parameters.AddWithValue("@unitsInStock", product.UnitsInStock);
            addProductCommand.Parameters.AddWithValue("@unitsOnOrder", product.UnitsOnOrder);
            addProductCommand.Parameters.AddWithValue("@reorderLevel", product.ReorderLevel);
            addProductCommand.Parameters.AddWithValue("@discontinued", product.Discontinued);
            addProductCommand.ExecuteNonQuery();
        }
    }
}
