using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class HomePage
    {

        private IWebDriver _driver;

        public HomePage(IWebDriver driver) => _driver = driver;

        IWebElement Classes => _driver.FindElement(By.CssSelector("#nav-classes > a"));


        //Save for homework
        //
        //Alternative to expression-bodied method
        IWebElement Programs
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#nav-programs > a"));
            }
        }
        IWebElement SearchBox => _driver.FindElement(By.Id("college-search-field"));
        IWebElement SearchButton => _driver.FindElement(By.CssSelector("#college-search-submit"));

        IWebElement Enrollment => _driver.FindElement(By.CssSelector("#nav-enrollment > a"));
        IWebElement Services => _driver.FindElement(By.CssSelector("#nav-services > a"));

        IWebElement CampusLife => _driver.FindElement(By.CssSelector("#nav-campuslife > a"));

        IWebElement AboutUs => _driver.FindElement(By.CssSelector("#nav-about > a"));
        IWebElement Title => _driver.FindElement(By.CssSelector("#content"));



        //In-Class
        public void ClickClasses() => Classes.Click();

        //Homework
        public void ClickPrograms() => Programs.Click();
        public void ClickEnrollment() => Enrollment.Click();
        public void ClickServices() => Services.Click();
        public void ClickCampusLife() => CampusLife.Click();
        public string GetTitleText() => Title.Text;
        public void ClickAbout() => AboutUs.Click();
        public void FillSearchBox(string searchString) => SearchBox.SendKeys("  " + searchString);
        public void ClickSearchButton() => SearchButton.Click();




    }
}
