using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;

namespace UtilitiesNameSpace
{
    public partial class Utilities
    {
        protected void NavigateToURL(string URL)
        {
            driver.driver.Navigate().GoToUrl(URL);
        }

        protected void ClearElement(Element Element, String ElementName)
        {
            try
            {
                driver.driver.FindElement(Element.ByElement).Clear();
            }

            catch
            {
                Assert.Fail("Cant clear " + ElementName);
            }

        }

        protected void InputValue(Element Element, String _Key, string ElementName)
        {
            try
            {
                driver.driver.FindElement(Element.ByElement).SendKeys(_Key);
            }

            catch
            {
                Assert.Fail("Cant input value to " + ElementName);
            }
        }

        protected void Clear_And_InputValue(double Time, Element Element, string Key, String ElementName)
        {
            //Locate the element
            Page_Should_Contains_Element(Time, Element, ElementName);

            //Clear Element
            ClearElement(Element, ElementName);

            //Send Keys to element
            InputValue(Element, Key, ElementName);
        }

        protected void ClickElement(Element Element, String ElementName)
        {
           
            Scroll_ToElement(Element, 160);

            HoverElement(Element);

            if (IsElementVisible(Element))
            {
                if (IsElementEnabled(Element))
                {

                    try
                    {
                        //Hover on the Element
                        HoverElement(Element);

                        //CLick Element
                        driver.driver.FindElement(Element.ByElement).Click();
                           
                    }

                    catch
                    {
                        Assert.Fail(ElementName, "is not Clickable.");

                    }
                }

                else
                    Assert.Fail(ElementName, "is not Enabled.");
            }

            else
                Assert.Fail(ElementName, "is not Visible.");

        }

        protected void Find_And_Click(double Time, Element Element, String ElementName)
        {
            //Locate the element
            Page_Should_Contains_Element(Time, Element, ElementName);

            //Click Element
            ClickElement(Element, ElementName);
        }

        protected void SelectFromList(Element Element, string ElementName, string selection)
        {
            try
            {
                new SelectElement(driver.driver.FindElement(Element.ByElement)).SelectByText(selection);
            }

            catch
            {
                Assert.Fail("Cant Select " + selection + " from " + ElementName);

            }
        }


        protected void Scroll_ToElement(Element Element, int YSpaceToSkip)
        {

            int elementPosition = driver.driver.FindElement(Element.ByElement).Location.Y - YSpaceToSkip;
            String js = String.Format("window.scroll(0, " + elementPosition + ")");
            ((IJavaScriptExecutor)driver.driver).ExecuteScript(js);

        }

        protected void Move_To_Element(Element Element)
        {
            if (driver.BrowserToTest == Browser.IE)
                ((IJavaScriptExecutor)driver.driver).ExecuteScript("arguments[0].scrollIntoView(true);", Element);

            else
            {
                Actions actions = new Actions(driver.driver);
                actions.MoveToElement(driver.driver.FindElement(Element.ByElement));
                actions.Perform();
            }

        }

        public void HoverElement(Element Element)
        {

            if (driver.BrowserToTest == Browser.IE)
                ((IJavaScriptExecutor)driver.driver).ExecuteScript("arguments[0].scrollIntoView(true);", Element);

            else
            {
                Actions builder = new OpenQA.Selenium.Interactions.Actions(driver.driver);

                builder.MoveToElement(driver.driver.FindElement(Element.ByElement)).Perform();


            }


        }


    }
}
