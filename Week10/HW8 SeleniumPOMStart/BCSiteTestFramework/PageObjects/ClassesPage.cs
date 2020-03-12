using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BCSiteTestFramework.PageObjects
{
    public class ClassesPage
    {

        //Not sure RemoteWebDriver is necessary.  private RemoteWebDriver
        private IWebDriver _driver;

        public ClassesPage(IWebDriver driver) => _driver = driver;  

        IWebElement Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#content > h2"));
            }
        }

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

        public string GetTitleText() => Title.Text;
    }
}
