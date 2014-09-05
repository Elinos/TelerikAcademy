using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TelerikAcademyModel;

namespace _02.SelectEmployeesFromGivenTown
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            string townName = "Sofia";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var employeesTowns = context.Employees.ToList()
                .Select(x => x.Address).ToList()
                .Select(x => x.Town).ToList()
                .Where(x => x.Name == townName).ToList();

            foreach (var town in employeesTowns)
            {
                Console.WriteLine(town.Name);
            }

            sw.Stop();

            Console.WriteLine("Query with many ToList invokations done in {0}", sw.Elapsed);
            Console.WriteLine("-----------------------------------------------------------");

            sw.Restart();

            employeesTowns = context.Employees
                .Select(x => x.Address)
                .Select(x => x.Town)
                .Where(x => x.Name == townName).ToList();

            foreach (var town in employeesTowns)
            {
                Console.WriteLine(town.Name);
            }

            sw.Stop();
            Console.WriteLine("Query with one ToList invokation in the end done in {0}", sw.Elapsed);
        }
    }
}
