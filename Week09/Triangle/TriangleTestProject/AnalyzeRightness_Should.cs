using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = Triangle_Final.Triangle;
using FluentAssertions;

namespace TriangleTestProject
{
    [TestClass]
    public class AnalyzeRightness_Should
    {
        [DataTestMethod]
        [DataRow(3, 4, 5, "Right triangle", DisplayName = "CaseID 1")]
        [DataRow(49, 36, 60, "Acute triangle", DisplayName = "CaseID 2")]
        [DataRow(12, 16, 22, "Obtuse triangle", DisplayName = "CaseID 3")]
        [DataRow(22, 12, 16, "Side c not longest", DisplayName = "CaseID 4")]
        [DataRow(4, 4, 16, "Not a triangle", DisplayName = "CaseID 5")]
        [DataRow(12, 12, 16, "Side c not longest", DisplayName = "CaseID 6")]
        [DataRow(22, 22, 16, "Side c not longest", DisplayName = "CaseID 7")]
        public void ReturnCorrectValue_WhenInputIsValid(int sideA, int sideB, int sideC, string expectedTriangle)
        {
            //Arrange
            string results;
            var triangle = new SUT() { SideA = sideA, SideB = sideB, SideC = sideC };

            //Act
            results = triangle.AnalyzeRightness();

            //Assert
            expectedTriangle.Should().Be(results);
        }
    }
}
