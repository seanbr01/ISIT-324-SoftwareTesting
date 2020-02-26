using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicActClassLibrary;
using Moq;
//using FluentAssertions;


namespace UnitTestProject1
{
    [TestClass]
    public class FindByGenre_Should
    {
        public List<MusicAct> LoadMockActs()
        {
            var listOfActs = new List<MusicAct>();
            listOfActs.Add(new MusicAct
            {
                Name = "Godsmack",
                Genre = "Metal",
                FavoriteSong = "Voodoo",
                StraightOutta = "Lawrence, MA"

            });

            listOfActs.Add(new MusicAct
            {
                Name = "Imagine Dragons",
                Genre = "Indie rock",
                FavoriteSong = "Radioactive",
                StraightOutta = "Las Vegas, NV"

            });

            listOfActs.Add(new MusicAct
            {
                Name = "Men Without Hats",
                Genre = "New Wave",
                FavoriteSong = "Safety Dance",
                StraightOutta = "Montreal, Canada"

            });


            listOfActs.Add(new MusicAct
            {
                Name = "Sevendust",
                Genre = "Metal",
                FavoriteSong = "Enemy",
                StraightOutta = "Atlanta, GA"

            });

            return listOfActs;
        }


        [TestMethod]
        public void ReturnZero_WhenGenreNotFound()
        {
            //Arrange

            Mock<IRepositoryOMusicActs> mockRep = new Mock<IRepositoryOMusicActs>();
            mockRep.Setup(x => x.GetActs()).Returns(LoadMockActs());
            var actController = new MusicActController(mockRep.Object);

            //Act
            List<MusicAct> result = actController.FindByGenre("Country");

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Return2_WhenGenreIsMetal()
        {
            //Arrange
            //var rep = new RepositoryOMusicActs();
            //var actController = new MusicActController(rep);

            Mock<IRepositoryOMusicActs> mockRep = new Mock<IRepositoryOMusicActs>();
            mockRep.Setup(x => x.GetActs()).Returns(LoadMockActs());
            var actController = new MusicActController(mockRep.Object);

            //Act
            List<MusicAct> result = actController.FindByGenre("metal");

            //Assert
            Assert.IsTrue(result.Count.Equals(2) && result[0].Name.Equals("Godsmack"));
        }

    }
}
