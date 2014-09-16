namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;

    public class StudentsSystemData
    {
        private readonly IStudentSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public StudentsSystemData() : this(new StudentSystemDbContext())
        {
        }

        public StudentsSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IRepository<Homework> Homeworks
        {
            get
            {
                return this.GetRepository<Homework>();
            }
        }

        public IRepository<Student> Students
        {
            get
            {
                return this.GetRepository<Student>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Student)))
                {
                    type = typeof(StudentsRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}