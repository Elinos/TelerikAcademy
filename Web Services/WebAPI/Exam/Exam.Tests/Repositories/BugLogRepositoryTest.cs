using System.Transactions;
using Exam.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Tests.Repositories
{
    [TestClass]
    public class DbBugLoggerRepositoryTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        //[TestMethod]
        //public void Find_WhenObjectIsInDb_ShouldReturnObject()
        //{
        //    //arrange
        //    var bug = this.GetValidTestBug();

        //    var dbContext = new ExamDbContext();
        //    var data = new ExamData(dbContext);

        //    data.Bugs.Add(bug);
        //    data.SaveChanges();

        //    //act
        //    var bugInDb = data.Bugs.Find(bug.Id);

        //    //asesrt

        //    Assert.IsNotNull(bugInDb);
        //    Assert.AreEqual(bug.Text, bugInDb.Text);
        //}

        //private Bug GetValidTestBug()
        //{
        //    var bug = new Bug()
        //    {
        //        Text = "Test New bug",
        //        LogDate = DateTime.Now,
        //        Status = Status.Pending
        //    };
        //    return bug;
        //}
    }
}
