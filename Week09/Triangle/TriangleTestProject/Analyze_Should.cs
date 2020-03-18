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
        [DataRow(25, 10, 15, "Not a triangle", DisplayName = "CaseID 1-3")]
        [DataRow(10, 25, 15, "Not a triangle", DisplayName = "CaseID 1-3")]
        [DataRow(10, 15, 25, "Not a triangle", DisplayName = "CaseID 1-3")]
        [DataRow(5, 10, 15, "Not a triangle", DisplayName = "CaseID 1-3")]
        [DataRow(10, 5, 15, "Not a triangle", DisplayName = "CaseID 1-3")]
        
        public void ReturnNotATriangle_WhenTwoSidesAreLessThanTheThird(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(2, 2, 3, "Isosceles", DisplayName = "CaseID 4-6")]
        [DataRow(2, 3, 2, "Isosceles", DisplayName = "CaseID 4-6")]
        [DataRow(3, 2, 2, "Isosceles", DisplayName = "CaseID 4-6")]
        public void ReturnIsosceles_WhenTwoSidesAreEqual(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(199, 199, 199, "Equilateral", DisplayName = "CaseID 7")]
        [DataRow(198, 198, 198, "Equilateral", DisplayName = "CaseID 7")]
        [DataRow(5, 5, 5, "Equilateral", DisplayName = "CaseID 7")]
        public void ReturnEquilateral_WhenSidesAreEqual(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(10, 15, 7, "Scalene", DisplayName = "CaseID 8")]
        [DataRow(10, 15, 8, "Scalene", DisplayName = "CaseID 8")]
        [DataRow(10, 15, 24, "Scalene", DisplayName = "CaseID 8")]
        [DataRow(10, 15, 23, "Scalene", DisplayName = "CaseID 8")]
        [DataRow(10, 15, 12, "Scalene", DisplayName = "CaseID 8")]
        public void ReturnScalene_WhenNoSidesAreEqual(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;

            //Act
            results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            expectedTriangle.Should().Be(results);
        }

        [DataTestMethod]
        [DataRow(0, 2, 3, DisplayName = "Case Less Than 1")]
        [DataRow(3, 0, 2, DisplayName = "Case Less Than 1")]
        [DataRow(3, 2, 0, DisplayName = "Case Less Than 1")]
        public void ThrowException_WhenSideIsZeroOrLess(int sideA, int sideB, int sideC)
        {
            //Arrange
            string results;

            //Act
            Action act = () => results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            act.Should().Throw<SideLessThanOneException>();
        }

        [DataTestMethod]
        [DataRow(198, 199, 201, DisplayName = "Case Greater Than 199")]
        [DataRow(198, 201, 199, DisplayName = "Case Greater Than 199")]
        [DataRow(201, 198, 199, DisplayName = "Case Greater Than 199")]
        public void ThrowException_WhenSideIsOver199(int sideA, int sideB, int sideC)
        {
            //Arrange
            string results;

            //Act
            Action act = () => results = SUT.Analyze(sideA, sideB, sideC);

            //Assert
            act.Should().Throw<LengthGreaterThan199Exception>();
        }
    }
}
