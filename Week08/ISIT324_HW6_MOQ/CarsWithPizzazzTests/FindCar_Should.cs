using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = CarsWithPizzazz;
using Moq;

namespace CarsWithPizzazzTests
{
    [TestClass]
    public class FindCar_Should
    {
        public SUT.Auto NewAudi;
        public Mock<SUT.IAutoDBAccess> mock;
        public SUT.AutoControl autoControl;
        public List<SUT.Auto> cars;

        [TestCleanup]
        public void testClean()
        {
            NewAudi = null;
            mock = null;
            autoControl = null;
            cars = null;
        }

        [TestInitialize]
        public void testInit()
        {
            NewAudi = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Audi", Model = "A4", LocationOnLot = "B5" };
            cars = new List<SUT.Auto>()
            {
                new SUT.Auto { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" },
                new SUT.Auto { VehicleIdentificationNumber = "02xxxxxxxxxxxxxxx", Year = "1964", Make = "Dodge", Model = "Dart", LocationOnLot = "F3" },
                new SUT.Auto { VehicleIdentificationNumber = "03xxxxxxxxxxxxxxx", Year = "1963", Make = "Cadillac", Model = "Fleetwood", LocationOnLot = "A23" },
                new SUT.Auto { VehicleIdentificationNumber = "04xxxxxxxxxxxxxxx", Year = "1995", Make = "Hummer", Model = "H1 (Gas)", LocationOnLot = "C7" },
                new SUT.Auto { VehicleIdentificationNumber = "05xxxxxxxxxxxxxxx", Year = "1958", Make = "Triumph", Model = "TR3", LocationOnLot = "A1" },
                new SUT.Auto { VehicleIdentificationNumber = "06xxxxxxxxxxxxxxx", Year = "1968", Make = "Triumph", Model = "TR5", LocationOnLot = "A2" }
            };

            mock = new Mock<SUT.IAutoDBAccess>();
            mock.Setup(x => x.LoadLot()).Returns(cars);
            mock.Setup(x => x.SaveLot(cars)).Returns(true);
            autoControl = new SUT.AutoControl(mock.Object);
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

            //Act
            var result = autoControl.FindCar(vin);

            //Assert
            Assert.AreEqual(locationOnLot, result.LocationOnLot);
        }

        [TestMethod]
        public void ThrowVINNotFoundException_WhenVinNotFound()
        {
            //Arrange

            //Act
            SUT.Auto result;

            //Assert
            Assert.ThrowsException<SUT.VINNotFoundException>(() => result = autoControl.FindCar(NewAudi.VehicleIdentificationNumber));
        }
    }

    [TestClass]
    public class FindCarByMake_Should
    {
        public SUT.Auto NewAudi;
        public Mock<SUT.IAutoDBAccess> mock;
        public SUT.AutoControl autoControl;
        public List<SUT.Auto> cars;

        [TestCleanup]
        public void testClean()
        {
            NewAudi = null;
            mock = null;
            autoControl = null;
            cars = null;
        }

        [TestInitialize]
        public void testInit()
        {
            NewAudi = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Audi", Model = "A4", LocationOnLot = "B5" };
            cars = new List<SUT.Auto>()
            {
                new SUT.Auto { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" },
                new SUT.Auto { VehicleIdentificationNumber = "02xxxxxxxxxxxxxxx", Year = "1964", Make = "Dodge", Model = "Dart", LocationOnLot = "F3" },
                new SUT.Auto { VehicleIdentificationNumber = "03xxxxxxxxxxxxxxx", Year = "1963", Make = "Cadillac", Model = "Fleetwood", LocationOnLot = "A23" },
                new SUT.Auto { VehicleIdentificationNumber = "04xxxxxxxxxxxxxxx", Year = "1995", Make = "Hummer", Model = "H1 (Gas)", LocationOnLot = "C7" },
                new SUT.Auto { VehicleIdentificationNumber = "05xxxxxxxxxxxxxxx", Year = "1958", Make = "Triumph", Model = "TR3", LocationOnLot = "A1" },
                new SUT.Auto { VehicleIdentificationNumber = "06xxxxxxxxxxxxxxx", Year = "1968", Make = "Triumph", Model = "TR5", LocationOnLot = "A2" }
            };

            mock = new Mock<SUT.IAutoDBAccess>();
            mock.Setup(x => x.LoadLot()).Returns(cars);
            mock.Setup(x => x.SaveLot(cars)).Returns(true);
            autoControl = new SUT.AutoControl(mock.Object);
        }

        [DataTestMethod]
        [DataRow("Dodge", 1)]
        [DataRow("Cadillac", 2)]
        [DataRow("Hummer", 1)]
        [DataRow("Triumph", 2)]
        [DataRow("Triumph", 2)]
        public void ReturnCorrectAutos_WhenMakeIsValid(string make, int expected)
        {
            //Arrange

            //Act
            var result = autoControl.FindCarsByMake(make);

            //Assert
            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Return0_WhenMakeDoesNotExsist()
        {
            //Arrange

            //Act
            var result = autoControl.FindCarsByMake(NewAudi.Make);

            //Assert
            Assert.AreEqual(0, result.Count);
        }
    }

    [TestClass]
    public class AddCar_Should
    {
        public SUT.Auto DuplicateCar;
        public SUT.Auto NewAudi;
        public SUT.Auto NewCarSameLot;
        public SUT.Auto NewCarInvalidVin;
        public Mock<SUT.IAutoDBAccess> mock;
        public SUT.AutoControl autoControl;
        public List<SUT.Auto> cars;

        [TestCleanup]
        public void testClean()
        {
            DuplicateCar = null;
            NewAudi = null;
            NewCarSameLot = null;
            NewCarInvalidVin = null;
            mock = null;
            autoControl = null;
            cars = null;
        }

        [TestInitialize]
        public void testInit()
        {
            DuplicateCar = new SUT.Auto() { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" };
            NewAudi = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Audi", Model = "A4", LocationOnLot = "B5" };
            NewCarSameLot = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Ford", Model = "Ranger", LocationOnLot = "A5" };
            NewCarInvalidVin = new SUT.Auto() { VehicleIdentificationNumber = "107xxxxxxxxxxxxxxx", Year = "2020", Make = "Ford", Model = "Ranger", LocationOnLot = "B5" };
            cars = new List<SUT.Auto>()
            {
                new SUT.Auto { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" },
                new SUT.Auto { VehicleIdentificationNumber = "02xxxxxxxxxxxxxxx", Year = "1964", Make = "Dodge", Model = "Dart", LocationOnLot = "F3" },
                new SUT.Auto { VehicleIdentificationNumber = "03xxxxxxxxxxxxxxx", Year = "1963", Make = "Cadillac", Model = "Fleetwood", LocationOnLot = "A23" },
                new SUT.Auto { VehicleIdentificationNumber = "04xxxxxxxxxxxxxxx", Year = "1995", Make = "Hummer", Model = "H1 (Gas)", LocationOnLot = "C7" },
                new SUT.Auto { VehicleIdentificationNumber = "05xxxxxxxxxxxxxxx", Year = "1958", Make = "Triumph", Model = "TR3", LocationOnLot = "A1" },
                new SUT.Auto { VehicleIdentificationNumber = "06xxxxxxxxxxxxxxx", Year = "1968", Make = "Triumph", Model = "TR5", LocationOnLot = "A2" }
            };

            mock = new Mock<SUT.IAutoDBAccess>();
            mock.Setup(x => x.LoadLot()).Returns(cars);
            mock.Setup(x => x.SaveLot(cars)).Returns(true);
            autoControl = new SUT.AutoControl(mock.Object);
        }

        [TestMethod]
        public void ReturnCorrectAutos_WhenMakeIsValid()
        {
            //Arrange

            //Act
            var results = autoControl.AddCar(NewAudi);

            //Assert
            Assert.AreEqual(7, results.Count);
            Assert.AreEqual(NewAudi.VehicleIdentificationNumber, results[results.Count -1].VehicleIdentificationNumber);
        }

        [TestMethod]
        public void ThrowDuplicateVINException_WhenDuplicateAddedToDB()
        {
            //Arrange

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.DuplicateVINException>(() => result = autoControl.AddCar(DuplicateCar));
        }

        [TestMethod]
        public void ThrowDuplicateLocationException_WhenNewCarHasDuplicateLot()
        {
            //Arrange

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.DuplicateLocationException>(() => result = autoControl.AddCar(NewCarSameLot));
        }

        [TestMethod]
        public void ThrowInvalidVINException_WhenNewCarHasInvalidVin()
        {
            //Arrange

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.InvalidVINException>(() => result = autoControl.AddCar(NewCarInvalidVin));
        }
    }

    [TestClass]
    public class RemoveCar_Should
    {
        public SUT.Auto NewAudi;
        public Mock<SUT.IAutoDBAccess> mock;
        public SUT.AutoControl autoControl;
        public List<SUT.Auto> cars;

        [TestCleanup]
        public void testClean()
        {
            NewAudi = null;
            mock = null;
            autoControl = null;
            cars = null;
        }

        [TestInitialize]
        public void testInit()
        {
            NewAudi = new SUT.Auto() { VehicleIdentificationNumber = "07xxxxxxxxxxxxxxx", Year = "2020", Make = "Audi", Model = "A4", LocationOnLot = "B5" };
            cars = new List<SUT.Auto>()
            {
                new SUT.Auto { VehicleIdentificationNumber = "01xxxxxxxxxxxxxxx", Year = "2008", Make = "Cadillac", Model = "CTS-V", LocationOnLot = "A5" },
                new SUT.Auto { VehicleIdentificationNumber = "02xxxxxxxxxxxxxxx", Year = "1964", Make = "Dodge", Model = "Dart", LocationOnLot = "F3" },
                new SUT.Auto { VehicleIdentificationNumber = "03xxxxxxxxxxxxxxx", Year = "1963", Make = "Cadillac", Model = "Fleetwood", LocationOnLot = "A23" },
                new SUT.Auto { VehicleIdentificationNumber = "04xxxxxxxxxxxxxxx", Year = "1995", Make = "Hummer", Model = "H1 (Gas)", LocationOnLot = "C7" },
                new SUT.Auto { VehicleIdentificationNumber = "05xxxxxxxxxxxxxxx", Year = "1958", Make = "Triumph", Model = "TR3", LocationOnLot = "A1" },
                new SUT.Auto { VehicleIdentificationNumber = "06xxxxxxxxxxxxxxx", Year = "1968", Make = "Triumph", Model = "TR5", LocationOnLot = "A2" }
            };

            mock = new Mock<SUT.IAutoDBAccess>();
            mock.Setup(x => x.LoadLot()).Returns(cars);
            mock.Setup(x => x.SaveLot(cars)).Returns(true);
            autoControl = new SUT.AutoControl(mock.Object);
        }

        [TestMethod]
        public void RemoveCorrectAuto_WhenCollectionContainsVin()
        {
            //Arrange
            var first = cars[0];

            //Act
            var results = autoControl.RemoveCar(first.VehicleIdentificationNumber);

            //Assert
            Assert.IsTrue(!results.Contains(first));
        }

        [TestMethod]
        public void ThrowVINNotFoundException_WhenVinNotInCollection()
        {
            //Arrange

            //Act
            List<SUT.Auto> result;

            //Assert
            Assert.ThrowsException<SUT.VINNotFoundException>(() => result = autoControl.RemoveCar(NewAudi.VehicleIdentificationNumber));
        }
    }
}
