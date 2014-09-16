namespace StudentSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using StudentSystem.Models;

    public class StudentsRepository : GenericRepository<Student>, IRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context) : base(context)
        {
        }
    }
}