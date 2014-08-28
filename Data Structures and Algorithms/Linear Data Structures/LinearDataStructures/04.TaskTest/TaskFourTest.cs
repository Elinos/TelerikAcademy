using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04.Task;

namespace _04.TaskTest
{
    [TestClass]
    public class TaskFourTest
    {
        [TestMethod]
        public void GetLongestSequenceTest()
        {
            var expected = new List<int> { 2, 2, 2 };
            var actual = TaskFour.GetLongestSequence(new List<int> { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 });
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
