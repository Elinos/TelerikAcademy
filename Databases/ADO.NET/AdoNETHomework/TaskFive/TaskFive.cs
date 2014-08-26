using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace TaskFive
{
    class TaskFive
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
                var images = ExtractImagesFromDB();
                for (int i = 0; i < images.Count; i++)
                {
                    WriteBinaryFile(String.Format(@"..\..\img{0}.jpeg", i), images[i]);
                }
            }
            finally
            {
                DisconnectFromDB();
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private static List<byte[]> ExtractImagesFromDB()
        {
            List<byte[]> images = new List<byte[]>();
            SqlCommand cmd = new SqlCommand("SELECT Picture FROM Categories", dbCon);

            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var rawImageData = (byte[])reader["Picture"];
                    int len = rawImageData.Length;
                    int header = 78;
                    byte[] image = new byte[len - header];
                    Array.Copy(rawImageData, 78, image, 0, len - header);

                    images.Add(image);
                }
            }
            return images;
        }
    }
}
