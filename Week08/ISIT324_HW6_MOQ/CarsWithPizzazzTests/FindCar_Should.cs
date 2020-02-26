using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = CarsWithPizzazz;
using Moq;
using FluentAssertions;

namespace CarsWithPizzazzTests
{
    [TestClass]
    public class FindCar_Should
    {
        public List<SUT.Auto> LoadMockAutos()
        {
            return new List<SUT.Auto>()
            {
                new SUT.Auto { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" },
                new SUT.Auto { VehicleIdentificationNumber = "02xxxxxxxxxxxxxxx", Year = "1964", Make = "Dodge", Model = "Dart", LocationOnLot = "F3" },
                new SUT.Auto { VehicleIdentificationNumber = "03xxxxxxxxxxxxxxx", Year = "1963", Make = "Cadillac", Model = "Fleetwood", LocationOnLot = "A23" },
                new SUT.Auto { VehicleIdentificationNumber = "04xxxxxxxxxxxxxxx", Year = "1995", Make = "Hummer", Model = "H1 (Gas)", LocationOnLot = "C7" },
                new SUT.Auto { VehicleIdentificationNumber = "05xxxxxxxxxxxxxxx", Year = "1958", Make = "Triumph", Model = "TR3", LocationOnLot = "A1" },
                new SUT.Auto { VehicleIdentificationNumber = "06xxxxxxxxxxxxxxx", Year = "1968", Make = "Triumph", Model = "TR5", LocationOnLot = "A2" }
            };
        }

        [DataTestMethod]
        [DataRow("01xxxxxxxxxxxxxxx", "A5")]
        [DataRow("02xxxxxxxxxxxxxxx", "F3")]
        [DataRow("03xxxxxxxxxxxxxxx", "A23")]
        [DataRow("04xxxxxxxxxxxxxxx", "C7")]
        [DataRow("05xxxxxxxxxxxxxxx", "A1")]
        [DataRow("06xxxxxxxxxxxxxxx", "A2")]
        public void ReturnCorrectLot_WhenVinIsValid(string vin, string locationOnLot)
        {
            //Arrange
            var autoController = MockDataBase();

            //Act
            var result = autoController.FindCar(vin);

            //Assert
            Assert.AreEqual(locationOnLot, result.LocationOnLot);
        }


        public void ReturnCorrectAutos_WhenMakeIsValid(string vin, string locationOnLot)
        {
            //Arrange
            var autoController = MockDataBase();

            //Act
            var result = autoController.FindCarsByMake(vin);

            //Assert
            Assert.AreEqual(locationOnLot, result.LocationOnLot);
        }

        private SUT.AutoControl MockDataBase()
        {
            Mock<SUT.IAutoDBAccess> mock = new Mock<SUT.IAutoDBAccess>();
            mock.Setup(x => x.LoadLot()).Returns(LoadMockAutos());
            return new SUT.AutoControl(mock.Object);
        }
    }
}
