using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = AnvilTotalPriceCalcExcercise;

namespace AnvilTotalTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalcPricePerAnvil_Return0_QuantityBelow0()
        {
            //Arrange
            var quantity = -10;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(0, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return0_Quantity0()
        {
            //Arrange
            var quantity = 0;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(0, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return10_Quantity1()
        {
            //Arrange
            var quantity = 1;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(10.00, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return10_Quantity9()
        {
            //Arrange
            var quantity = 9;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(10.00, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return9_Quantity10()
        {
            //Arrange
            var quantity = 10;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(9, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return9_Quantity19()
        {
            //Arrange
            var quantity = 19;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(9, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return8_Quantity20()
        {
            //Arrange
            var quantity = 20;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(8, results);
        }

        [TestMethod]
        public void CalcPricePerAnvil_Return8_Quantity999()
        {
            //Arrange
            var quantity = 999;
            var regPrice = 10.00;

            //Act
            var results = SUT.PriceCalc.CalcPricePerAnvil(quantity, regPrice);

            //Assert
            Assert.AreEqual(8, results);
        }

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
