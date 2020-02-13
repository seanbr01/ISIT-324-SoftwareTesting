using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = Midterm.OddOrPosClass;
using FluentAssertions;

namespace OddOrPosTests
{
    [TestClass]
    public class OddOrPosShould
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 3)]
        [DataRow(new int[] { 1, 2, 3, 10, 20 }, 5)]
        [DataRow(new int[] { -1, 2, -3 }, 3)] // fails pre-correction
        public void OddOrPos_ShouldReturnCorrectValue_WhenInputCorrect(int[] data, int expected)
        {
            //Arrange
            int result;

            //Act
            result = SUT.OddOrPos(data);

            //Assert
            expected.Should().Be(result);
        }

        [DataTestMethod]
        [DataRow(null)]
        public void OddOrPos_ShouldThrowException_WhenInputNull(int[] data)
        {
            //Arrange
            int result;

            //Act


            //Assert
            Assert.ThrowsException<NullReferenceException>(() => result = SUT.OddOrPos(data));
        }
    }
}
