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


        [ClassCleanup]
        public static void StopSeleniumDriver()
        {
            Driver.QuitDriver();
        }

    }
}

