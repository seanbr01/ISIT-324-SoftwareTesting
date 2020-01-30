using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = NFLMath.YardageCalculation;
using FluentAssertions;

namespace UnitTestProject1
{
    [TestClass]
    public class FieldGoalDistance_Should
    {
        [DataTestMethod]
        [DataRow("OPP", 30, 47)]
        public void ReturnsCorrectDistanceWhenInputsAreValid(string end, int lineOfScrimage, int expectedDistance)
        {
            //Arrange
            int fieldGoalDistance;

            //Act
            fieldGoalDistance = SUT.FieldGoalDistance(end, lineOfScrimage);

            //Assert
            expectedDistance.Should().Be(fieldGoalDistance);
        }
    }
}
