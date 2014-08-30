using System;
using System.Linq;
using UsingEntityFramework;

namespace _04.OrdersWithNativeQuery
{
    public class NativeQuery
    {
        static void Main(string[] args)
        {
            var db = new NorthwindEntities();
            var query = "SELECT c.ContactName AS Name, YEAR(o.ShippedDate) AS ShippedYear, o.ShipCountry AS Destination FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID WHERE YEAR(o.ShippedDate) = 1997 AND o.ShipCountry = 'Canada'";
            var selectedCustomers = db.Database.SqlQuery<CustomerAndOrder>(query);
            foreach (var customer in selectedCustomers)
            {
                Console.WriteLine("Name: {0} | Year: {1} | Destination: {2}",
                                  customer.Name, customer.ShippedYear, customer.Destination);
            }

        }
    }
}
