using BCSiteTestFramework;
using BCSiteTestFramework.PageObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BCSiteTest
{
    [TestClass]
    public class HomePage_Should
    {
        AboutPage aboutPage;
        CampusLifePage campusLife;
        ClassesPage classesPage;
        EnrollmentPage enrollment;
        HomePage homePage;
        ProgramsOfStudyPage programsOfStudy;
        ServicesPage services;

        const string ABOUT_PAGE_TITLE = "About Us";
        const string CAMPUS_LIFE_PAGE_TITLE = "Campus Life";
        const string CLASSES_PAGE_TITLE = "Browse Credit Classes";
        const string ENROLLMENT_PAGE_TITLE = "Student Central";
        const string PROGRAMS_OF_STUDY_PAGE_TITLE = "Programs";
        const string SERVICES_PAGE_TITLE = "Campus Services";
        
        public const string WINTER_QUARTER = "Winter2020";
        public const string SPRING_QUARTER = "Spring2020";
        public const string SEARCH_FOR_ISIT324 = "ISIT 324";
        public const string SEARCH_FOR_MINIUM = "dennis minium";

        [TestInitialize]
        public void InitDriver()
        {
            Driver.InitializeDriver();
            aboutPage = new AboutPage(Driver.BCTestDriver);
            campusLife = new CampusLifePage(Driver.BCTestDriver);
            classesPage = new ClassesPage(Driver.BCTestDriver);
            enrollment = new EnrollmentPage(Driver.BCTestDriver);
            homePage = new HomePage(Driver.BCTestDriver);
            programsOfStudy = new ProgramsOfStudyPage(Driver.BCTestDriver);
            services = new ServicesPage(Driver.BCTestDriver);
        }

        [TestMethod]
        public void ReturnClassesPage_WhenClassesClicked()
        {
            //Arrange
            string result;

            //Act
            homePage.ClickClasses();
            result = classesPage.GetTitleText();

            //Assert
            result.Should().Be(CLASSES_PAGE_TITLE);
        }

        [TestMethod]
        public void ReturnAboutPage_WhenAboutClicked()
        {
            //Arrange
            string result;

            //Act
            homePage.ClickAbout();
            result = aboutPage.GetTitleText();

            //Assert
            result.Should().Be(ABOUT_PAGE_TITLE);
        }

        [TestMethod]
        public void ReturnListOfPages_WhenEachMenuItemClicked()
        {
            //Arrange
            List<string> results = new List<string>();

            //Act
            homePage.ClickClasses();
            results.Add(classesPage.GetTitleText());
            Driver.GoBack();

            homePage.ClickPrograms();
            results.Add(programsOfStudy.GetTitleText());
            Driver.GoBack();

            homePage.ClickEnrollment();
            results.Add(enrollment.GetTitleText());
            Driver.GoBack();

            homePage.ClickServices();
            results.Add(services.GetTitleText());
            Driver.GoBack();

            homePage.ClickCampusLife();
            results.Add(campusLife.GetTitleText());
            Driver.GoBack();

            homePage.ClickAbout();
            results.Add(aboutPage.GetTitleText());

            //Assert
            results.Should().Equal(new List<string> { CLASSES_PAGE_TITLE, PROGRAMS_OF_STUDY_PAGE_TITLE, ENROLLMENT_PAGE_TITLE, SERVICES_PAGE_TITLE, CAMPUS_LIFE_PAGE_TITLE, ABOUT_PAGE_TITLE });
        }

        [DataTestMethod]
        [DataRow("ISIT 324 Software Testing • 5 Cr.", WINTER_QUARTER, SEARCH_FOR_ISIT324)]
        [DataRow("PROG 110 Introduction to Programming • 5 Cr.", SPRING_QUARTER, SEARCH_FOR_MINIUM)]
        public void ReturnCorrectSearchResults_WhenSearchingForClasses(string expected, string quarter, string search)
        {
            //Arrange
            string searchResult;

            //Act
            homePage.ClickClasses();
            classesPage.SelectSearchQuarter(quarter);
            searchResult = classesPage.Search(search);

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

