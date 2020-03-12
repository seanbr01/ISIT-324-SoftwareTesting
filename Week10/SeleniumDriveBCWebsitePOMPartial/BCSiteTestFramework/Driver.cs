using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSiteTestFramework
{
    public static class Driver
    {
        public static IWebDriver BCTestDriver = new ChromeDriver();

        public static void InitializeDriver() => BCTestDriver.Navigate().GoToUrl("https://www.bellevuecollege.edu/");

        public static void QuitDriver() => BCTestDriver.Quit();

        public static void GoBack() => BCTestDriver.Navigate().Back();
    }
}
