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

        IWebElement SearchResultDetailHeading => _driver.FindElement(By.CssSelector("#content > h2:nth-child(2)"));
        IWebElement FinalScheduleLink => _driver.FindElement(By.CssSelector("#main > div.row > div > div > div.container > div.well.classes-links > div > div:nth-child(2) > ul > li:nth-child(1) > a"));
        IWebElement CanvasMenuLink => _driver.FindElement(By.Id("branded-top-actions-canvas"));
        public string GetTitleText() => Title.Text;
        public void ClickSearchResult() => SearchResultDetail.Click();
        public void ClickCanvasMenuLink() => CanvasMenuLink.Click();
        public void ClickFinalScheduleLink() => FinalScheduleLink.Click();
        public string GetSearchResultDetailText() => SearchResultDetail.Text + " >> " + SearchResultDetailHeading.Text;


        public bool SelectSearchQuarter(string quarter)
        {
            SelectElement s = new SelectElement(SearchQuarterSelect);
            try
            {
                s.SelectByValue(quarter);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string Search(string searchString)
        {
            SearchBox.SendKeys(searchString);
            SearchButton.Click();

            SearchResultFirstInstance.Click();
            return SearchResultDetail.Text;
        }
    }
}
