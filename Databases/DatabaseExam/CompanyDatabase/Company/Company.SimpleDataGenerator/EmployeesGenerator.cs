using Company.Data;
using RandomDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.SimpleDataGenerator
{
    public class EmployeesGenerator : DataGenerator, IDataGenerator
    {
        public EmployeesGenerator(CompanyEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Generating Employees");

            var departmentsIds = this.Db.Departments.Select(d => d.ID).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var currentEmployeesIds = this.Db.Employees.Select(d => d.ID).ToList();
                var newEmployee = new Employee
                {
                    FirstName = this.Random.GetString(5, 20),
                    LastName = this.Random.GetString(5, 20),
                    YearSalary = this.Random.GetInt(50000, 200000),
                    DepartmentID = departmentsIds[this.Random.GetInt(0, departmentsIds.Count - 1)],
                };

                if (currentEmployeesIds.Count > 0)
                {
                    int? selectedManagerID = this.Random.GetChance(95) ? currentEmployeesIds[this.Random.GetInt(0, currentEmployeesIds.Count - 1)] : default(int?);
                    if (selectedManagerID == null)
                    {
                        newEmployee.ManagerID = selectedManagerID;
                    }
                    else
                    {
                        var forbiddenIDs = CheckManagers((int)selectedManagerID);
                        while (forbiddenIDs.Contains((int)selectedManagerID))
                        {
                            selectedManagerID = this.Random.GetChance(95) ? currentEmployeesIds[this.Random.GetInt(0, currentEmployeesIds.Count - 1)] : default(int?);
                            forbiddenIDs = CheckManagers((int)selectedManagerID);
                        }
                        newEmployee.ManagerID = selectedManagerID;
                    }
                }

                this.Db.Employees.Add(newEmployee);
                Db.SaveChanges();
                if (i % 100 == 0)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine("\nGenerating Employees Done!");
        }

        private HashSet<int> CheckManagers(int selectedManagerID)
        {
            var manager = Db.Employees.Find(selectedManagerID);
            var forbiddenIDs = new HashSet<int>();
            while (manager.ManagerID != null)
            {
                forbiddenIDs.Add(manager.ManagerID.Value);
                manager = Db.Employees.Find(manager.ManagerID.Value);
            }
            return forbiddenIDs;
        }
    }
}
