using Company.Data;
using RandomDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.SimpleDataGenerator
{
    public class ProjectsGenerator : DataGenerator, IDataGenerator
    {
        public ProjectsGenerator(CompanyEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Generating Projects");
            var employeesIds = this.Db.Employees.Select(d => d.ID).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var newProject = new Project
                {
                    Name = this.Random.GetString(5, 50),
                };
                if (employeesIds.Count > 1)
                {
                    var uniqueEmployeesIds = new HashSet<int>();
                    var employeesInProject = this.Random.GetInt(2, Math.Min(employeesIds.Count - 1, 20));
                    while (uniqueEmployeesIds.Count != employeesInProject)
                    {
                        uniqueEmployeesIds.Add(employeesIds[this.Random.GetInt(0, employeesIds.Count - 1)]);
                    }
                    foreach (var uniqueEmployeeId in uniqueEmployeesIds)
                    {
                        var startingDate = DateTime.Now.AddDays(this.Random.GetInt(-5, 10));
                        var endingDate = startingDate.AddDays(this.Random.GetInt(1, 5));
                        var newEmployeesProject = new EmployeesProject
                        {
                            Employee = this.Db.Employees.Find(uniqueEmployeeId),
                            Project = newProject,
                            StartingDate = startingDate,
                            EndingDate = endingDate
                        };
                        newProject.EmployeesProjects.Add(newEmployeesProject);
                    }
                }
                this.Db.Projects.Add(newProject);
                if (i % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }

            Console.WriteLine("\nGenerating Projects Done!");
        }
    }
}
