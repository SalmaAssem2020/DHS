using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace UtilitiesNameSpace
{
    [Flags]
    public enum Browser { IE, Chrome, FireFox, AndroidChrome, Edge, SauceLabsChrome };

    public class Driver
    {
        public IWebDriver driver;
        private string baseURL;
        public bool RunOnMobile = false;
        public Browser BrowserToTest;

        public Driver(Browser browser)
        {
            BrowserToTest = browser;
            if (browser == Browser.Chrome)
            {

                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--start-maximized");

               driver = new ChromeDriver(options);

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMinutes(2);


            }

            else if (browser == Browser.IE)
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.RequireWindowFocus = true;
                driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(4);
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMinutes(4);
            }


        }


        public void FreshSetup(string URL)
        {
            baseURL = URL;
            driver.Navigate().GoToUrl(baseURL);
        }

        public void NavigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }

        public void TeardownDriver()
        {
            try
            {
                driver.Close();
                driver.Quit(); 
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

    }
}
