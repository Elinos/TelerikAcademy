using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;

namespace TaskSix
{
    class TaskSixAndSeven
    {
        private static OleDbConnection dbCon;

        private static void ConnectToDB()
        {
            ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["ExcelDB"];
            dbCon = new OleDbConnection(dBConnectionString.ConnectionString);
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

                InsertRecord("Pesho", 55);

                var records = RetrieveListOfRecords();
                foreach (var record in records)
                {
                    Console.WriteLine("{0} - {1}", record.Name, record.Score);
                }
            }
            finally
            {
                DisconnectFromDB();
            }
        }

        private static void InsertRecord(string name, int score)
        {
            string commandText = "INSERT INTO [Records$] (Name, Score) VALUES(@name, @score)";
            OleDbCommand insertCommand = new OleDbCommand(commandText, dbCon);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@score", score);
            insertCommand.ExecuteNonQuery();
        }

        private static List<Record> RetrieveListOfRecords()
        {
            List<Record> records = new List<Record>();
            
            OleDbCommand retrieveCommand = new OleDbCommand("SELECT * FROM [Records$]", dbCon);
            OleDbDataReader reader = retrieveCommand.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int score = (int)(double)reader["Score"];

                    Record record = new Record(name, score);
                    records.Add(record);
                }

                return records;
            }
        }
    }
}
