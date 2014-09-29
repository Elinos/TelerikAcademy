using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Exam.Data.Repositories;

namespace Exam.Data
{
    public class ExamData : IExamData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public ExamData(ExamDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        //TODO: Add Repositories
        //public IRepository<Article> Articles
        //{
        //    get { return this.GetRepository<Article>(); }
        //}
     
        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
