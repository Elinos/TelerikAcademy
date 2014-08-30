using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEntityFramework;

namespace _2.DAO
{
    public class UsingDAO
    {
        public static void Main()
        {
            Console.WriteLine(DAO.InsertCustomer(new Customer { CustomerID = "12345", ContactName = "Test", CompanyName = "Teeest" }));
        }
    }
}
