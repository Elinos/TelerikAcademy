namespace StudentSystem.Data
{
    using System;
    using System.Linq;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;

    public interface IStudentSystemData
    {
        IRepository<Course> Courses { get; }

        IRepository<Student> Students { get; }

        IRepository<Homework> Homeworks { get; }
    }
}