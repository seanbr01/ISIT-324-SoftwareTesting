using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class CampusLife
    {
        private IWebDriver _driver;

        public CampusLife(IWebDriver driver) => _driver = driver;

        IWebElement About => _driver.FindElement(By.CssSelector("#nav-campuslife > a"));

        IWebElement Title => _driver.FindElement(By.CssSelector("#site-header > p > a"));

        public void ClickAbout() => About.Click();

        public string GetTitleText() => Title.Text;
    }
}
