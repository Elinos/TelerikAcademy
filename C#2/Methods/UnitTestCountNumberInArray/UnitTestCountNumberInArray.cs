using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCountNumberInArray
{
    [TestClass]
    public class UnitTestCountNumberInArray
    {
        [TestMethod]
        public void CountNumberInArray()
        {
            int expected = 4;
            int[] testArray = {1, 2, 1, 3, 1, 4, 1};
            int testNumber = 1;
            int actual = NumberCount.CountNumberInArray(testArray, testNumber);
            Assert.AreEqual(expected, actual);
        }
    }
}
