using System;
using System.Linq;
using UsingEntityFramework;

namespace CustomerOrdersByDateAndDestination
{
    public class SelectOrders
    {
        static void Main(string[] args)
        {
            var db = new NorthwindEntities();
            var selectedCustomers = db.Orders
                .Where(o => o.ShippedDate.Value.Year == 1997 &&
                       o.ShipCountry == "Canada")
                .Select(o => new
                        {
                            Name = o.Customer.ContactName,
                            ShippedYear = o.ShippedDate.Value.Year,
                            Destination = o.ShipCountry
                        });
            foreach (var customer in selectedCustomers)
            {
                Console.WriteLine("Name: {0} | Year: {1} | Destination: {2}",
                                  customer.Name, customer.ShippedYear, customer.Destination);
            }
        }
    }
}
