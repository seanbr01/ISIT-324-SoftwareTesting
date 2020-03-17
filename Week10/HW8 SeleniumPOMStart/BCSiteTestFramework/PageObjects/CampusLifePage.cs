using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class CampusLifePage
    {
        private IWebDriver _driver;

        public CampusLifePage(IWebDriver driver) => _driver = driver;

        IWebElement About => _driver.FindElement(By.CssSelector("#nav-campuslife > a"));

        IWebElement Title => _driver.FindElement(By.CssSelector("#site-header > p > a"));

        public void ClickAbout() => About.Click();

        public string GetTitleText() => Title.Text;
    }
}
