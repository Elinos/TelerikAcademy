using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace TaskThree
{
    class TaskThree
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
                List<Product> products = RetrieveProductNameAndCategory();
                foreach (var product in products)
                {
                    Console.WriteLine("{0} - {1}", product.ProductName, product.ProductCategory);
                }
            }
            finally
            {
                DisconnectFromDB();
            }
        }

        private static List<Product> RetrieveProductNameAndCategory()
        {
            List<Product> products = new List<Product>();
            string commandText = "SELECT p.ProductName, c.CategoryName FROM Products p 	INNER JOIN Categories c ON p.CategoryID = c.CategoryID";
            SqlCommand cmdSelectProject = new SqlCommand(commandText, dbCon);
            SqlDataReader reader = cmdSelectProject.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["ProductName"];
                    string description = (string)reader["CategoryName"];

                    Product product = new Product(name, description);
                    products.Add(product);
                }

                return products;
            }
        }
    }
}
