using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BCSiteTestFramework.PageObjects
{
    public class ClassesPage
    {

        //Not sure RemoteWebDriver is necessary.  private RemoteWebDriver
        private IWebDriver _driver;

        public ClassesPage(IWebDriver driver) => _driver = driver;

        IWebElement Title => _driver.FindElement(By.CssSelector("#content > h2"));

        //IWebElement Title => _driver.FindElement(By.CssSelector("#content > h2"));

        /*********************************************************************
         * 
         * Here are some additional elements for the Classes page I found
         * that I required to complete the homework assignment:
         * 
         * - SearchBox
         * - SearchQuarterSelect
         * - SearchButton
         * - SearchResultFirstInstance
         * - SearchResultDetail
         * 
         *********************************************************************/
        IWebElement SearchBox => _driver.FindElement(By.CssSelector("#search-keyword"));
        IWebElement SearchQuarterSelect => _driver.FindElement(By.Id("seach-quarter-select"));
        IWebElement SearchButton => _driver.FindElement(By.CssSelector("#submitSearchForm > div > div > span > button"));
        IWebElement SearchResultFirstInstance => _driver.FindElement(By.CssSelector("#content > h3 > a"));
        IWebElement SearchResultDetail => _driver.FindElement(By.CssSelector("#content > h1"));

        public string GetTitleText() => Title.Text;
    }
}
