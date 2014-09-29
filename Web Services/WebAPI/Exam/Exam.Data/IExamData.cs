using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public interface IExamData
    {
        //TODO: Add Repositories
        //IRepository<Comment> Comments { get; }
        int SaveChanges();
    }
}
