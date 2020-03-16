using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class ProgramsOfStudy
    {
        private IWebDriver _driver;

        public ProgramsOfStudy(IWebDriver driver) => _driver = driver;

        IWebElement About => _driver.FindElement(By.CssSelector("#nav-programs > a"));

        IWebElement Title => _driver.FindElement(By.CssSelector("#site-header > p > a"));

        public void ClickAbout() => About.Click();

        public string GetTitleText() => Title.Text;
    }
}
