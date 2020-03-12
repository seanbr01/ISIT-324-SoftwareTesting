using System;
using System.Collections.Generic;
using BCSiteTestFramework;
using BCSiteTestFramework.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;

namespace BCSiteTest
{

    [TestClass]

    public class HomePage_Should
    {
        public const string WINTER_QUARTER = "Winter2020";
        public const string SPRING_QUARTER = "Spring2020";
        public const string SEARCH_FOR_ISIT324 = "ISIT 324";
        public const string SEARCH_FOR_MINIUM = "dennis minium";

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




        //HOMEWORK FROM SCRATCH
        [TestMethod]
        [DataRow("ISIT 324 Software Testing • 5 Cr.", WINTER_QUARTER, SEARCH_FOR_ISIT324)]
        [DataRow("PROG 110 Introduction to Programming • 5 Cr.", SPRING_QUARTER, SEARCH_FOR_MINIUM)]
        public void ReturnCorrectSearchResults_WhenSearchingForClasses(string expected, string quarter, string search)
        {
            //Arrange
            HomePage hp = new HomePage(Driver.BCTestDriver);
            ClassesPage cp = new ClassesPage(Driver.BCTestDriver);

            //Act
            hp.ClickClasses();
            cp.SelectSearchQuarter(quarter);
            string searchResult = cp.Search(search);

            //Assert
            Assert.AreEqual(expected, searchResult);
            searchResult.Should().Be(expected);
        }


        [ClassCleanup]
        public static void StopSeleniumDriver()
        {
            Driver.QuitDriver();
        }

    }
}

