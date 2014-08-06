namespace ComputersTests
{
    using System;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SquareNumberTests
    {
        [TestMethod]
        public void Test128BitCpu()
        {
            var test128BitCpu = new Cpu128Bit(2);
            var expectedLowNumber = "Number too low.";
            var expectedHighNumber = "Number too high.";
            var expectedResult = "Square of 2000 is 4000000.";
            Assert.AreEqual(expectedLowNumber, test128BitCpu.SquareNumber(-1));
            Assert.AreEqual(expectedHighNumber, test128BitCpu.SquareNumber(2001));
            Assert.AreEqual(expectedResult, test128BitCpu.SquareNumber(2000));
        }

        [TestMethod]
        public void Test32BitCpu()
        {
            var test32BitCpu = new Cpu32Bit(2);
            var expectedLowNumber = "Number too low.";
            var expectedHighNumber = "Number too high.";
            var expectedResult = "Square of 500 is 250000.";
            Assert.AreEqual(expectedLowNumber, test32BitCpu.SquareNumber(-1));
            Assert.AreEqual(expectedHighNumber, test32BitCpu.SquareNumber(501));
            Assert.AreEqual(expectedResult, test32BitCpu.SquareNumber(500));
        }

        [TestMethod]
        public void Test64BitCpu()
        {
            var test64BitCpu = new Cpu64Bit(2);
            var expectedLowNumber = "Number too low.";
            var expectedHighNumber = "Number too high.";
            var expectedResult = "Square of 1000 is 1000000.";
            Assert.AreEqual(expectedLowNumber, test64BitCpu.SquareNumber(-1));
            Assert.AreEqual(expectedHighNumber, test64BitCpu.SquareNumber(1001));
            Assert.AreEqual(expectedResult, test64BitCpu.SquareNumber(1000));
        }
    }
}
