using Company.Data;
using RandomDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.SimpleDataGenerator
{
    public class ReportsGenerator : DataGenerator, IDataGenerator
    {
        public ReportsGenerator(CompanyEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Generating Reports");
            var employeesIds = this.Db.Employees.Select(d => d.ID).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var newReport = new Report
                {
                    Time = DateTime.Now.AddDays(this.Random.GetInt(-50, 0)),
                    EmployeeID = employeesIds[this.Random.GetInt(0, employeesIds.Count - 1)],
                };

                this.Db.Reports.Add(newReport);
                if (i % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }

            Console.WriteLine("\nGenerating Reports Done!");
        }
    }
}
