using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = AnvilTotalPriceCalcExcercise;

namespace AnvilTotalTests
{
    [TestClass]
    public class CalcShippingCostPerAnvil_Tests
    {
        [TestMethod]
        public void CalcShippingCostPerAnvil_Return10_Zone1()
        {
            //Arrange
            var zone = 1;

            //Act
            var results = SUT.PriceCalc.CalcShippingCostPerAnvil(zone);

            //Assert
            Assert.AreEqual(10, results);
        }

        [TestMethod]
        public void CalcShippingCostPerAnvil_Return30_Zone3()
        {
            //Arrange
            var zone = 3;

            //Act
            var results = SUT.PriceCalc.CalcShippingCostPerAnvil(zone);

            //Assert
            Assert.AreEqual(30, results);
        }

        [TestMethod]
        public void CalcShippingCostPerAnvil_IndexOutOfRangeException_Zone4()
        {
            //Arrange
            var zone = 4;

            //Act

            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => SUT.PriceCalc.CalcShippingCostPerAnvil(zone));
        }

        [TestMethod]
        public void CalcShippingCostPerAnvil_IndexOutOfRangeException_ZoneBelow0()
        {
            //Arrange
            var zone = -1;

            //Act

            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => SUT.PriceCalc.CalcShippingCostPerAnvil(zone));
        }
    }
}
