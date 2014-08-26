using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace TaskTwo
{
    class TaskTwo
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
                List<Category> categories = RetrieveNameAndDiscription();
                foreach (var category in categories)
                {
                    Console.WriteLine("{0} - {1}", category.Name, category.Description);
                }
            }
            finally
            {
                DisconnectFromDB();
            }
        }

        private static List<Category> RetrieveNameAndDiscription()
        {
            List<Category> categories = new List<Category>();
            SqlCommand retrieveCommand = new SqlCommand("SELECT * FROM Categories", dbCon);
            SqlDataReader reader = retrieveCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];

                    Category category = new Category(name, description);
                    categories.Add(category);
                }

                return categories;
            }
        }
    }
}
