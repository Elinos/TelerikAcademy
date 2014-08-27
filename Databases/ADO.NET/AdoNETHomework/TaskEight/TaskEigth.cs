using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace TaskEight
{
    class TaskEigth
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
                string pattern = "ch";
                List<Product> products = GetAllProducts(pattern);
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }

            }
            finally
            {
                DisconnectFromDB();
            }
        }

        private static List<Product> GetAllProducts(string pattern)
        {
            var products = new List<Product>();
            string commandText = "SELECT * FROM Products WHERE CHARINDEX(@match, ProductName) > 0";
            SqlCommand retrieveCommand = new SqlCommand(commandText, dbCon);
            retrieveCommand.Parameters.AddWithValue("@match", pattern);
            SqlDataReader reader = retrieveCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["ProductName"];
                    Product product = new Product(name);
                    products.Add(product);
                }
                return products;
            }
        }
    }
}
