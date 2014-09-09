using System;
using System.Collections.Generic;
using System.Linq;
using Company.Data;
using RandomDataGenerator;

namespace Company.SimpleDataGenerator
{
    public class SampleDataGenerator
    {
        public static void Main()
        {
            var random = RandomData.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentsGenerator(db, random, 100),
                new EmployeesGenerator(db, random, 5000),
                new ProjectsGenerator(db, random, 1000),
                new ReportsGenerator(db, random, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
