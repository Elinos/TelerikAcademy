namespace ComputersTests
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class GenerateRandomNumberTests
    {
        [TestMethod]
        public void TestDoesItGenerateNumber()
        {
            byte cores = 2;
            var testCpu = Mock.Create<Cpu>(Behavior.CallOriginal, cores);
            Mock.Arrange(() => testCpu.GenerateRandomNumber(Arg.AnyInt, Arg.AnyInt)).Returns(5);
            var expected = 5;
            var actual = testCpu.GenerateRandomNumber(1, 10);
            Assert.AreEqual(expected, actual);
        }
    }
}
