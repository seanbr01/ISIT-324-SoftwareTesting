using BCSiteTestFramework;
using BCSiteTestFramework.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCSiteTest
{
    [TestClass]
    public class HomePage_Should
    {

        [TestInitialize]
        public void InitDriver()
        {
            Driver.InitializeDriver();
        }

        [TestMethod]
        public void ReturnClassesPage_WhenClassesClicked()
        {
            //Arrange
            HomePage hp = new HomePage(Driver.BCTestDriver);
            ClassesPage cp = new ClassesPage(Driver.BCTestDriver);
            string result;
            string expected = "Browse Credit Classes";

            //Act
            hp.ClickClasses();
            result = cp.GetTitleText();

            //Assert
            result.Should().Be(expected);
        }


        [TestMethod]
        public void ReturnAboutPage_WhenAboutClicked()
        {
            //Arrange
            HomePage hp = new HomePage(Driver.BCTestDriver);
            AboutPage ap = new AboutPage(Driver.BCTestDriver);
            string result;
            string expected = "About Us";

            //Act
            hp.ClickAbout();
            result = ap.GetTitleText();

            //Assert
            result.Should().Be(expected);
        }

        //[TestMethod]
        //public void Test()
        //{
        //    //Arrange
        //    HomePage hp = new HomePage(Driver.BCTestDriver);
        //    ProgramsOfStudy ap = new ProgramsOfStudy(Driver.BCTestDriver);
        //    string result;
        //    string expected = "Programs";

        //    //Act
        //    hp.ClickPrograms();
        //    result = ap.GetTitleText();

        //    //Assert
        //    result.Should().Be(expected);
        //}

        [TestMethod]
        public void ReturnListOfPages_WhenEachMenuItemClicked()
        {
            //Arrange
            HomePage hp = new HomePage(Driver.BCTestDriver);
            AboutPage ap = new AboutPage(Driver.BCTestDriver);
            string result;
            string expected = "About Us";

            //Act
            hp.ClickAbout();
            result = ap.GetTitleText();

            //Assert
            result.Should().Be(expected);
        }

        [ClassCleanup]
        public static void StopSeleniumDriver()
        {
            Driver.QuitDriver();
        }

    }
}

