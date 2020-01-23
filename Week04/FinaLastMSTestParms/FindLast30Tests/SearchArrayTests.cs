using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindLast30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUT = FindLast30.SearchArray;

namespace FindLast30.Tests
{
    [TestClass()]
    public class FindLastTest_Should
    {
        [DataTestMethod]
        [DataRow(new int[] { 2, 3, 5 } ,2, 0)]
        [DataRow(new int[] { 2, 3, 5 }, 3, 1)]
        [DataRow(new int[] { 2, 3, 5 }, 5, 2)]
        public void ReturnIndex_ForSearchValueInArray(int[] testArray, int y, int z)
        {
            //Arrange

            //Act
            int result = SUT.FindLast(testArray, y);

            //Assert
            Assert.AreEqual(z, result);
        }

        [TestMethod]
        public void ReturnMinus1_ForSearchValueNotInArray()
        {
            //Arrange
            int[] x = new int[] { 2, 3, 5 };
            int y = 7;

            //Act
            int result = SUT.FindLast(x, y);

            //Assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenArrayIsNull()
        {
            //Arrange
            int[] x = null;
            int y = 7;

            //Act
            Assert.ThrowsException<NullReferenceException>(() => SUT.FindLast(x, y));

            //Assert

        }


    }
}