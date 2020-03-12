using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = HW8_Triangle;
using FluentAssertions;

namespace UnitTestProject1
{
    [TestClass]
    public class AnalyzeTest_Should
    {
        [DataTestMethod]
        [DataRow(0, 1, 1)]
        [DataRow(201, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 201, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(1, 1, 201)]
        public void ReturnException_WhenInvalidValue(int sideA, int sideB, int sideC)
        {
            //Arrange
            SUT.Triangle t = new SUT.Triangle();
            t.SideA = sideA;
            t.SideB = sideB;
            t.SideC = sideC;

            //Act (well, actually more Arrange)
            Action test = () => { t.AnalyzeType(); };

            //Assert
            test.Should().Throw<SUT.InvalidSideException>();

        }

        [DataTestMethod]
        [DataRow(4, 1, 2, "Not a triangle", DisplayName = "Case 1")]
        [DataRow(1, 4, 2, "Not a triangle", DisplayName = "Case 2")]
        [DataRow(1, 2, 4, "Not a triangle", DisplayName = "Case 3")]
        [DataRow(5, 5, 5, "Equilateral", DisplayName = "Case 4")]
        //Cases 5 and 6 are impossible 
        [DataRow(2, 2, 3, "Isosceles", DisplayName = "Case 7")]
        //Case 8 is impossible 
        [DataRow(2, 3, 2, "Isosceles", DisplayName = "Case 9")]
        [DataRow(3, 2, 2, "Isosceles", DisplayName = "Case 10")]
        [DataRow(3, 4, 5, "Scalene", DisplayName = "Case 11")]

        public void ReturnCorrectString_WhenInputIsValid(int sideA, int sideB, int sideC, string expected)
        {
            //Arrange
            SUT.Triangle t = new SUT.Triangle();
            t.SideA = sideA;
            t.SideB = sideB;
            t.SideC = sideC;

            //Act
            string result = t.AnalyzeType();

            //Assert
            result.Should().Be(expected);
        }

    }
}
