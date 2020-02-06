using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = AnvilTotalPriceCalcExcercise;

namespace AnvilTotalTests
{
    [TestClass]
    public class CalcShippingCostPerAnvil_Should
    {
        [DataTestMethod]
        [DataRow(1, 10)]
        [DataRow(2, 20)]
        [DataRow(3, 30)]
        public void CalcShippingCostPerAnvil_ReturnCorrectValue_WhenInputValid(int zone, double expected)
        {
            //Arrange
            double results;

            //Act
            results = SUT.PriceCalc.CalcShippingCostPerAnvil(zone);

            //Assert
            Assert.AreEqual(expected, results);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(4)]
        public void CalcShippingCostPerAnvil_ThrowIndexOutOfRangeException_WhenInputIsInvalid(int zone)
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => SUT.PriceCalc.CalcShippingCostPerAnvil(zone));
        }
    }
}
