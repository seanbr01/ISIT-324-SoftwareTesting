using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class Services
    {
        private IWebDriver _driver;

        public Services(IWebDriver driver) => _driver = driver;

        IWebElement About => _driver.FindElement(By.CssSelector("#nav-services > a"));

        IWebElement Title => _driver.FindElement(By.CssSelector("#site-header > p > a"));

        public void ClickAbout() => About.Click();

        public string GetTitleText() => Title.Text;
    }
}
