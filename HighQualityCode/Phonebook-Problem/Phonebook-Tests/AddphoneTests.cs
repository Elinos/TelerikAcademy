using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;

namespace PhonebookTests
{
    /// <summary>
    /// Summary description for JustMockTest
    /// </summary>
    [TestClass]
    public class AddphoneTests
    {
        [TestMethod]
        public void TestAddphoneWithNewEntry()
        {
            var testPhoneDatabase = new PhonebookRepository();
            bool isNewEntry = testPhoneDatabase.AddPhone("TestUser", new string[] { "+359899777235" });
            Assert.IsTrue(isNewEntry);
        }

        [TestMethod]
        public void TestAddphoneWithExistingEntry()
        {
            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUser", new string[] { "+359899777235" });
            bool isNewEntry = testPhoneDatabase.AddPhone("testuser", new string[] { "+359888777235" });
            Assert.IsFalse(isNewEntry);
        }

        [TestMethod]
        public void TestAddingMoreNumbers()
        {
            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUser", new string[] { "+359899777235" });
            bool isNewEntry = testPhoneDatabase.AddPhone("testuser", new string[] { "+359888777777", "359888777666", "359888777555" });
            Assert.IsFalse(isNewEntry);
        }
    }
}
