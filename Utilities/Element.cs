using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UtilitiesNameSpace
{


    public enum LocateBy 
    {
        Id = 1,
        XPath = 2,
        TagName = 3,
        Name = 4,
        CssSelector = 5,
        LinkText = 6
    }
    
    public class Element
    {
        public By ByElement { get; set; }
        public LocateBy LocatedBy { get; set; }
        public string LocatorString { get; set; }
        
        public Element() { }

        public Element(LocateBy ByMethod, string LocatorValue = "")
        {
            ByElement = ByElementLocator(ByMethod, LocatorValue);
            LocatorString = LocatorValue;
            LocatedBy = ByMethod;
        }

        /// <summary>
        /// Reduce the verbosity of the code used for creating locators by using this unified method
        /// </summary>
        /// <param name="LocateBy"></param>
        /// <param name="ByLocatorString"></param>
        /// <returns></returns>
        public By ByElementLocator(LocateBy LocatedBy, string ByLocatorString)
        {
            //Reset to a null object to remove any garbage
            ByElement = null;

            if (!string.IsNullOrEmpty(ByLocatorString))
            {
                switch (LocatedBy)
                {
                    case LocateBy.Id:
                        ByElement = By.Id(ByLocatorString);
                        break;

                    case LocateBy.Name:
                        ByElement = By.Name(ByLocatorString);
                        break;

                    case LocateBy.XPath:
                        ByElement = By.XPath(ByLocatorString);
                        break;

                    case LocateBy.CssSelector:
                        ByElement = By.CssSelector(ByLocatorString);
                        break;

                    case LocateBy.TagName:
                        ByElement = By.TagName(ByLocatorString);
                        break;

                    case LocateBy.LinkText:
                        ByElement = By.LinkText(ByLocatorString);
                        break;

                    default:
                        throw new ArgumentException();

                }//end switch

            }//endif: there's a locator value

            return ByElement;

        }//end method ByElementLocator

        /// <summary>
        /// Use Element to return selenium IWebElement
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public IWebElement ReturnWebElement(IWebDriver driver)
        {
            IWebElement WebElement = driver.FindElement(ByElement);

            return WebElement;
        }


    }
    
}
