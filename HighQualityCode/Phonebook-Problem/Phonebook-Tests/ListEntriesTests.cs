using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;

namespace Phonebook_Tests
{
    [TestClass]
    public class ListEntriesTests
    {
        [TestMethod]
        public void TestListPhonesWithNoEntries()
        {
            try
            {
                var testPhoneDatabase = new PhonebookRepository();
                testPhoneDatabase.ListEntries(0, 1);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }

        }

        [TestMethod]
        public void TestWithInvalidRange()
        {
            try
            {
                var testPhoneDatabase = new PhonebookRepository();
                testPhoneDatabase.ListEntries(-1, 0);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }

        }

        [TestMethod]
        public void TestWithOneEntry()
        {
            var testName = "TestUser";
            var testNumbers = new SortedSet<string> { "+359899777235", "+359888777777" };
            ListEntries[] expected = new ListEntries[] { new ListEntries { Name = testName, Numbers = testNumbers } };
            string expectedToString = expected.ToString();

            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUser", new string[] { "+359899777235" });
            testPhoneDatabase.AddPhone("testuser", new string[] { "+359888777777" });

            var actual = testPhoneDatabase.ListEntries(0, 1);
            string actualToString = actual.ToString();

            Assert.AreEqual(expectedToString, actualToString);
        }

        [TestMethod]
        public void TestWithSeveralEntries()
        {
            var testNameOne = "TestUserOne";
            var testNameTwo = "TestUserTwo";
            var testNumbersOne = new SortedSet<string> { "+359899777235" };
            var testNumbersTwo = new SortedSet<string> { "+359888777777" };

            ListEntries listEntryOne = new ListEntries { Name = testNameOne, Numbers = testNumbersOne };
            ListEntries listEntryTwo = new ListEntries { Name = testNameTwo, Numbers = testNumbersTwo };
            ListEntries[] expected = new ListEntries[] { listEntryOne, listEntryTwo };
            string expectedToString = expected.ToString();

            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUserOne", new string[] { "+359899777235" });
            testPhoneDatabase.AddPhone("TestUserTwo", new string[] { "+359888777777" });

            var actual = testPhoneDatabase.ListEntries(0, 1);
            string actualToString = actual.ToString();

            Assert.AreEqual(expectedToString, actualToString);
        }
    }
}
