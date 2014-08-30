using System;
using System.Linq;
using UsingEntityFramework;

namespace _05.SalesByRegionAndPeriod
{
    class SalesByRegionAndPeriod
    {
        static void Main(string[] args)
        {
            var db = new NorthwindEntities();
            var region = "WA";
            var startDate = new DateTime(1996, 10, 1);
            var endDate = new DateTime(1998, 10, 1);
            FindSalesByRegionAndPeriod(region, startDate, endDate);
            
        }

        private static void FindSalesByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            var db = new NorthwindEntities();
            var sales = db.Orders.Where(o => o.ShipRegion == region &&
                                        o.OrderDate >= startDate &&
                                        o.OrderDate <= endDate)
                                 .Select(o => new
                                 {
                                     Region = o.ShipRegion,
                                     OrderDate = o.OrderDate
                                 });
            foreach (var sale in sales)
            {
                Console.WriteLine("Region: {0} - OrderDate {1}", sale.Region, sale.OrderDate);
            }
        }
    }
}
