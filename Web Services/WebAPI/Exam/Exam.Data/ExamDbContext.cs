using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Data.Migrations;
using Exam.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Exam.Data
{
    public class ExamDbContext : IdentityDbContext<User>
    {
        public ExamDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, Configuration>());
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }
        //TODO: Add IdbSets
        //public IDbSet<Article> Articles { get; set; }
    }
}
