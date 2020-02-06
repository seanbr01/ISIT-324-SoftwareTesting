using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = AnvilTotalPriceCalcExcercise;

namespace AnvilTotalTests
{
    [TestClass]
    public class CalcPricePerAnvil_Should
    {
        [TestMethod]
        public void CalcPricePerAnvil_Return0_WhenPriceBelow0()
        {
            //Arrange
            var quantity = 10;
            var regPrice = -999.99;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(0, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return0_WhenQuantityBelow0()
        {
            //Arrange
            var quantity = -10;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(0, results);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 10)]
        [DataRow(9, 10)]
        [DataRow(10, 9)]
        [DataRow(19, 9)]
        [DataRow(20, 8)]
        [DataRow(999, 8)]
        public void CalcPricePerAnvil_ReturnCorrectValue_WhenQuantityIsValid(int quantity, double expected)
        {
            //Arrange
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(expected, results);
        }
    }
}
