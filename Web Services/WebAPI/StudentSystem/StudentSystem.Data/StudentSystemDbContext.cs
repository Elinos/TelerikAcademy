namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class StudentSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDbContext() : base("StudentSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}