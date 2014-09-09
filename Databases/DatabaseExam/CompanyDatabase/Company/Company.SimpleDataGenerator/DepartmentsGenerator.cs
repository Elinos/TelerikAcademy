using Company.Data;
using RandomDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.SimpleDataGenerator
{
    public class DepartmentsGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentsGenerator(CompanyEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Generating Departments");

            var uniqueDepartmentsNames = new HashSet<string>();

            while (uniqueDepartmentsNames.Count != this.Count)
            {
                uniqueDepartmentsNames.Add(this.Random.GetString(10, 50));
            }
            var index = 0;
            foreach (var uniqueName in uniqueDepartmentsNames)
            {
                var newDepartment = new Department
                {
                    Name = uniqueName
                };
                Db.Departments.Add(newDepartment);
                index++;
                if (index % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }

            Console.WriteLine("\nGenerating Departments Done!");
        }
    }
}
