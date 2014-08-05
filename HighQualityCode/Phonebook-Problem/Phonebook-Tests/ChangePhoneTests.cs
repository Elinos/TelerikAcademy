using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;

namespace Phonebook_Tests
{
    [TestClass]
    public class ChangePhoneTests
    {
        [TestMethod]
        public void TestChangePhoneWithOneNumber()
        {
            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUser", new string[] { "+359899777235" });
            testPhoneDatabase.AddPhone("TestUserTwo", new string[] { "+359888777777" });
            int countOfChangedNumbers = testPhoneDatabase.ChangePhone("+359899777235", "+359899777333");
            Assert.AreEqual(1, countOfChangedNumbers);
        }

        [TestMethod]
        public void TestChangePhoneWithSeveralNumbers()
        {
            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("UserOne", new string[] { "+359899777235", "+359888777777" });
            testPhoneDatabase.AddPhone("UserTwo", new string[] { "+359888777777" });
            testPhoneDatabase.AddPhone("UserThree", new string[] { "+359888777777", "+359899777235" });
            int countOfChangedNumbers = testPhoneDatabase.ChangePhone("+359888777777", "+359888888888");
            Assert.AreEqual(3, countOfChangedNumbers);
        }
    }
}
