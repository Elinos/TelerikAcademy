namespace ComputersTests
{
    using System;
    using System.Linq;
    using Computers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryTests
    {
        [TestMethod]
        public void TestInitialBatteryPercentage()
        {
            var testBattery = new LaptopBattery();
            var expected = 50;
            var actual = testBattery.Percentage;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOverchargedBattery()
        {
            var testBattery = new LaptopBattery();
            var expected = 100;
            testBattery.Charge(51);
            var actual = testBattery.Percentage;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEmptyBattery()
        {
            var testBattery = new LaptopBattery();
            var expected = 0;
            testBattery.Charge(-51);
            var actual = testBattery.Percentage;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeMethodWithPositiveNumber()
        {
            var testBattery = new LaptopBattery();
            var expected = 51;
            testBattery.Charge(1);
            var actual = testBattery.Percentage;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeMethodWithNegativeNumber()
        {
            var testBattery = new LaptopBattery();
            var expected = 49;
            testBattery.Charge(-1);
            var actual = testBattery.Percentage;
            Assert.AreEqual(expected, actual);
        }
    }
}
