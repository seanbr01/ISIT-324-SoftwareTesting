using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = ISIT_324_04.Triangle;
using FluentAssertions;
using Triangle;

namespace TriangleTestProject
{
    [TestClass]
    public class Analyze_Should
    {
        [DataTestMethod]
        [DataRow(2, 2, 2, "Equilateral")]
        [DataRow(3, 3, 3, "Equilateral")]
        [DataRow(4, 4, 4, "Equilateral")]
        [DataRow(5, 5, 5, "Equilateral")]
        public void Analyse_ShouldReturnEquilateral_WhenSidesAreEqual(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(2, 2, 3, "Isosceles")]
        [DataRow(3, 2, 2, "Isosceles")]
        [DataRow(2, 3, 2, "Isosceles")]
        public void Analyse_ShouldReturnIsosceles_WhenTwoSidesAreEqual(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(8, 7, 12, "Scalene")]
        [DataRow(10, 14, 15, "Scalene")]
        [DataRow(7, 13, 14, "Scalene")]
        public void Analyse_ShouldReturnScalene_WhenNoSidesAreEqual(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(0, 2, 3)]
        [DataRow(3, -1, -2)]
        [DataRow(-6, -9, -5)]
        public void Analyse_ShouldReturnException_WhenSideIsZeroOrLess(int sideA, int sideB, int sideC)
        {
            //Arrange
            string results;

            //Act
            Action act = () => results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            act.Should().Throw<SideLessThanOneException>();
        }

        [DataTestMethod]
        [DataRow(2, 2, 5)]
        [DataRow(16, 5, 7)]
        [DataRow(6, 999, 1)]
        public void Analyse_ShouldReturnException_WhenTwoSidesAreLessThanTheThird(int sideA, int sideB, int sideC)
        {
            //Arrange
            string results;

            //Act
            Action act = () => results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            act.Should().Throw<TwoSidesCannotBeLessThanThirdSideException>();
        }
    }
}
