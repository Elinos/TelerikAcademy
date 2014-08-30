using System;
using System.Linq;
using UsingEntityFramework;

namespace SupplierIncome
{
    class SupplierIncome
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindEntities())
            {
                var result = context.usp_FindTotalIncome(new DateTime(1994, 1, 1), new DateTime(2000, 12, 31), "Exotic Liquids").First();

                Console.WriteLine("All Income are {0}", result);
            }
        }

        /*
         * USE northwind
        GO

        CREATE PROC usp_FindTotalIncome (@startDate datetime,  @endDate DateTime, @companyName nvarchar(50))
        AS
        SELECT SUM(od.Quantity*od.UnitPrice) AS TotalIncome
        FROM Suppliers s
        INNER JOIN Products p
        ON s.SupplierID = p.SupplierID
        INNER JOIN [ORDER Details] od
        ON od.ProductID = p.ProductID
        INNER JOIN Orders o
        ON od.OrderID = o.OrderID
        WHERE s.CompanyName = @companyName AND (o.OrderDate >= @startDate AND o.OrderDate <= @endDate)
        GO
         * */
    }
}
