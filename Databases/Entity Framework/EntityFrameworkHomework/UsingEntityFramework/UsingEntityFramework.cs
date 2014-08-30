using System;
using System.Linq;

namespace UsingEntityFramework
{
    class UsingEntityFramework
    {
        static void Main(string[] args)
        {
            var db = new NorthwindEntities();
            var empInLondon = db.Employees.Where(e => e.City == "London").Select(e => e.FirstName);
            foreach (var emp in empInLondon)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
