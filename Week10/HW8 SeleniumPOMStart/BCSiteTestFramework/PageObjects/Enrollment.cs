using OpenQA.Selenium;

namespace BCSiteTestFramework.PageObjects
{
    public class Enrollment
    {
        private IWebDriver _driver;

        public Enrollment(IWebDriver driver) => _driver = driver;

        IWebElement About => _driver.FindElement(By.CssSelector("#nav-enrollment > a"));

        IWebElement Title => _driver.FindElement(By.CssSelector("#site-header > p > a"));

        public void ClickAbout() => About.Click();

        public string GetTitleText() => Title.Text;
    }
}
