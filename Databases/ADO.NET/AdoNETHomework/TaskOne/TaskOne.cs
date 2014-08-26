using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace TaskOne
{
    public static class TaskOne
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
        

        private static int GetNumberOfRows(string columnName)
        {
            string commandText = String.Format("SELECT COUNT(*) FROM {0}", columnName);
            SqlCommand getNumberOfRowsCommand = new SqlCommand(commandText, dbCon);
            return (int)getNumberOfRowsCommand.ExecuteScalar();
        }

        static void Main() 
        {
            try
            {
                ConnectToDB();
                string tableName = "Categories";
                int numberOfRows = GetNumberOfRows(tableName);
                Console.WriteLine("Total number of rows in table {0} is {1}", tableName, numberOfRows);
            }
            finally
            {
                DisconnectFromDB();
            }
        }
    }
}

