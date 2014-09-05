using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TelerikAcademyModel;

namespace _01.SelectEmployeesData_N_1Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var employees = context.Employees;

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1} {2} from {4} works in {3}",
                    employee.FirstName,employee.MiddleName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }

            sw.Stop();

            Console.WriteLine("Without Include done in {0}", sw.Elapsed);
            Console.WriteLine("-----------------------------------------");

            sw.Restart();

            employees = context.Employees;

            foreach (var employee in employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("{0} {1} {2} from {4} works in {3}",
                    employee.FirstName, employee.MiddleName, employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }

            sw.Stop();

            Console.WriteLine("With Include done in {0}", sw.Elapsed);
        }
    }
}
