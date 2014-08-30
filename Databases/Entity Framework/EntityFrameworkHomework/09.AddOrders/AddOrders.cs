using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using UsingEntityFramework;

namespace _09.AddOrders
{
    class AddOrders
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Last three orders before transaction\n");
            GetLastThreeCities();

            Console.WriteLine("\nStart of transaction\n");
            AddThreeOrdersUsingTransaction();
            Console.WriteLine("\nEnd of transaction\n");

            Console.WriteLine("\nLast three orders after transaction\n");
            GetLastThreeCities();
        }

        private static void GetLastThreeCities()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var maxOrderId =
                    context.Orders.OrderByDescending(x => x.OrderID).First().OrderID;

                var lastThreeOrders = (from o in context.Orders
                                       where o.OrderID > maxOrderId - 3
                                       select new { o.ShipCity, o.OrderID });

                foreach (var orderInfo in lastThreeOrders)
                {
                    Console.WriteLine("City: {0} OrderId: {1}", orderInfo.ShipCity, orderInfo.OrderID);
                }
            }
        }

        private static void AddThreeOrdersUsingTransaction()
        {
            // Note: max lenght of shipCity is 15.
            string[] shipCityNames = { "Persepolis", "Cartagen", "Chargoggagoggmanchauggagoggchaubunagungamaugg Lake" };

            using (TransactionScope scope = new TransactionScope())
            {
                using (NorthwindEntities context = new NorthwindEntities())
                {
                    try
                    {
                        foreach (var shipCity in shipCityNames)
                        {
                            Order order = new Order
                            {
                                ShipCity = shipCity
                            };

                            context.Orders.Add(order);
                            context.SaveChanges();
                        }

                        scope.Complete();
                    }
                    catch (DbEntityValidationException deve)
                    {
                        DbEntityValidationResult result = deve.EntityValidationErrors.First();
                        DbValidationError error = result.ValidationErrors.First();

                        Console.WriteLine("Invalid order property: {0}",
                            error.PropertyName);
                    }
                }
            }
        }
    }
}
