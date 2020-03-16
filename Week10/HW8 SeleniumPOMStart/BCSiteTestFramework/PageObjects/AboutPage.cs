using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class AboutPage
    {
        private IWebDriver _driver;

        public AboutPage(IWebDriver driver) => _driver = driver;

        IWebElement About => _driver.FindElement(By.CssSelector("#nav-about > a"));

        IWebElement Title => _driver.FindElement(By.CssSelector("#site-header > p > a"));

        public void ClickAbout() => About.Click();

        public string GetTitleText() => Title.Text;
    }
}
