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
            var testMethods = new TestMethods();
            var autoController = testMethods.MockDataBase();

            //Act
            var result = autoController.FindCar(vin);

            //Assert
            Assert.AreEqual(locationOnLot, result.LocationOnLot);
        }

        [TestMethod]
        public void ReturnVINNotFoundException_WhenVinNotFound()
        {
            //Arrange
            var testMethods = new TestMethods();
            var autoController = testMethods.MockDataBase();

            //Act
            SUT.Auto result;

            //Assert
            Assert.ThrowsException<SUT.VINNotFoundException>(() => result = autoController.FindCar(""));
        }
    }

    [TestClass]
    public class FindCarByMake_Should
    {
        [DataTestMethod]
        [DataRow("Dodge", 1)]
        [DataRow("Cadillac", 2)]
        [DataRow("Hummer", 1)]
        [DataRow("Triumph", 2)]
        [DataRow("Triumph", 2)]
        public void ReturnCorrectAutos_WhenMakeIsValid(string make, int expected)
        {
            //Arrange
            var testMethods = new TestMethods();
            var autoController = testMethods.MockDataBase();

            //Act
            var result = autoController.FindCarsByMake(make);

            //Assert
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Return0_WhenMakeDoesNotExsist()
        {
            //Arrange
            var expected = 0;
            var make = "Audi";
            var testMethods = new TestMethods();
            var autoController = testMethods.MockDataBase();

            //Act
            var result = autoController.FindCarsByMake(make);

            //Assert
            Assert.AreEqual(expected, result.Count);
        }
    }

    [TestClass]
    public class AddCar_Should
    {
        [TestMethod]
        public void ReturnCorrectAutos_WhenMakeIsValid()
        {
            //Arrange
            var testMethods = new TestMethods();
            var mock = testMethods.AddToMockDatabase();

            var autoControl = new SUT.AutoControl(mock.Object);

            //Act
            var results = autoControl.AddCar(testMethods.NewCar);

            //Assert
            Assert.AreEqual(7, results.Count);
            Assert.AreEqual(testMethods.NewCar.VehicleIdentificationNumber, results[results.Count -1].VehicleIdentificationNumber);
        }

        [TestMethod]
        public void ThrowException_WhenDuplicateAddedToDB()
        {
            //Arrange
            var testMethods = new TestMethods();
            var mock = testMethods.AddToMockDatabase();

            var autoControl = new SUT.AutoControl(mock.Object);

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.DuplicateVINException>(() => result = autoControl.AddCar(testMethods.DuplicateCar));
        }

        [TestMethod]
        public void ThrowException_WhenNewCarHasDuplicateLot()
        {
            //Arrange
            var testMethods = new TestMethods();
            var mock = testMethods.AddToMockDatabase();

            var autoControl = new SUT.AutoControl(mock.Object);

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.DuplicateLocationException>(() => result = autoControl.AddCar(testMethods.NewCarSameLot));
        }

        [TestMethod]
        public void ThrowException_WhenNewCarHasInvalidVin()
        {
            //Arrange
            var testMethods = new TestMethods();
            var mock = testMethods.AddToMockDatabase();

            var autoControl = new SUT.AutoControl(mock.Object);

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.InvalidVINException>(() => result = autoControl.AddCar(testMethods.NewCarInvalidVin));
        }
    }

    [TestClass]
    public class RemoveCar_Should
    {
        [TestMethod]
        public void ReturnCorrectAutos_WhenMakeIsValid()
        {
            //Arrange
            var testMethods = new TestMethods();
            var mock = testMethods.AddToMockDatabase();

            var autoControl = new SUT.AutoControl(mock.Object);

            var first = testMethods.LoadMockAutos()[0];

            //Act
            var results = autoControl.RemoveCar(first.VehicleIdentificationNumber);

            //Assert
            Assert.IsNotNull(results.Contains(first));
        }

        [TestMethod]
        public void ThrowException_WhenDuplicateAddedToDB()
        {
            //Arrange
            var testMethods = new TestMethods();
            var mock = testMethods.AddToMockDatabase();

            var autoControl = new SUT.AutoControl(mock.Object);

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.VINNotFoundException>(() => result = autoControl.RemoveCar(testMethods.NewCar.VehicleIdentificationNumber));
        }
    }

    public class TestMethods
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

        public SUT.Auto DuplicateCar = new SUT.Auto() { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" };
        public SUT.Auto NewCar = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Ford", Model = "Ranger", LocationOnLot = "B5" };
        public SUT.Auto NewCarSameLot = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Ford", Model = "Ranger", LocationOnLot = "A5" };
        public SUT.Auto NewCarInvalidVin = new SUT.Auto() { VehicleIdentificationNumber = "107xxxxxxxxxxxxxxx", Year = "2020", Make = "Ford", Model = "Ranger", LocationOnLot = "B5" };

        public SUT.AutoControl MockDataBase()
        {
            Mock<SUT.IAutoDBAccess> mock = new Mock<SUT.IAutoDBAccess>();
            mock.Setup(x => x.LoadLot()).Returns(LoadMockAutos());
            return new SUT.AutoControl(mock.Object);
        }

        public Mock<SUT.IAutoDBAccess> AddToMockDatabase()
        {
            var cars = LoadMockAutos();

            var mock = new Mock<SUT.IAutoDBAccess>();

            mock.Setup(x => x.LoadLot()).Returns(cars);
            mock.Setup(x => x.SaveLot(cars)).Returns(true);

            return mock;
        }
    }
}
