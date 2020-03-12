using BCSiteTestFramework;
using BCSiteTestFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrySeleniumOnBCSiteWithPOM
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver.InitializeDriver();

            HomePage home = new HomePage(Driver.BCTestDriver);
            ClassesPage cp = new ClassesPage(Driver.BCTestDriver);

            //Muck around on CLASSES page
            WriteCurrentPage(home.GetTitleText());
            home.ClickClasses();

            WriteCurrentPage(cp.GetTitleText());
            cp.SelectSearchQuarter("Winter2019");
            string temp = cp.Search("ISIT 324");
            WriteCurrentPage(temp);
            cp.ClickSearchResult();
            WriteCurrentPage(cp.GetTitleText());


            Driver.BCTestDriver.Quit();

            Console.WriteLine("\n*** END SIMULATION ***");
            Console.ReadKey();
        }

        static void WriteCurrentPage(string title)
        {
            Console.WriteLine($"CurrentPage: '{title}'");
        }

        static void TakeScreenShot(string title)
        {
            try
            {
                //Take the screenshot
                Screenshot image = ((ITakesScreenshot)Driver.BCTestDriver).GetScreenshot();
                //Save the screenshot
                string fileName = ($"C:\\users\\denni\\desktop\\{title}.png");  //<--Substitute a filename you can access on your machine before this'll work.
                image.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                Console.WriteLine($"Took a pic of {title}.  It's at {fileName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
