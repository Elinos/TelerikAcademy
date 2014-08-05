namespace Phonebook_Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook;
    using System.Collections;

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
            ListEntry[] expected = new ListEntry[] { new ListEntry { Name = testName, Numbers = testNumbers } };

            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUser", new string[] { "+359899777235" });
            testPhoneDatabase.AddPhone("testuser", new string[] { "+359888777777" });

            var actual = testPhoneDatabase.ListEntries(0, 1);

            Assert.AreEqual(expected.Count(), actual.Count());

            IEnumerator e1 = expected.GetEnumerator();
            IEnumerator e2 = actual.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                Assert.AreEqual(e1.Current.ToString(), e2.Current.ToString());
            }
        }

        [TestMethod]
        public void TestWithSeveralEntries()
        {
            var testNameOne = "TestUserOne";
            var testNameTwo = "TestUserTwo";
            var testNumbersOne = new SortedSet<string> { "+359899777235" };
            var testNumbersTwo = new SortedSet<string> { "+359888777777" };

            ListEntry listEntryOne = new ListEntry { Name = testNameOne, Numbers = testNumbersOne };
            ListEntry listEntryTwo = new ListEntry { Name = testNameTwo, Numbers = testNumbersTwo };
            ListEntry[] expected = new ListEntry[] { listEntryOne, listEntryTwo };

            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUserOne", new string[] { "+359899777235" });
            testPhoneDatabase.AddPhone("TestUserTwo", new string[] { "+359888777777" });

            var actual = testPhoneDatabase.ListEntries(0, 2);

            Assert.AreEqual(expected.Count(), actual.Count());

            IEnumerator e1 = expected.GetEnumerator();
            IEnumerator e2 = actual.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                Assert.AreEqual(e1.Current.ToString(), e2.Current.ToString());
            }
        }

        [TestMethod]
        public void TestPages()
        {
            var testNameTwo = "TestUserTwo";
            var testNumbersTwo = new SortedSet<string> { "+359888777777" };

            ListEntry listEntryTwo = new ListEntry { Name = testNameTwo, Numbers = testNumbersTwo };
            ListEntry[] expected = new ListEntry[] { listEntryTwo };

            var testPhoneDatabase = new PhonebookRepository();
            testPhoneDatabase.AddPhone("TestUserOne", new string[] { "+359899777235" });
            testPhoneDatabase.AddPhone("TestUserTwo", new string[] { "+359888777777" });

            var actual = testPhoneDatabase.ListEntries(1, 1);

            Assert.AreEqual(expected.Count(), actual.Count());

            IEnumerator e1 = expected.GetEnumerator();
            IEnumerator e2 = actual.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                Assert.AreEqual(e1.Current.ToString(), e2.Current.ToString());
            }
        }
    }
}
