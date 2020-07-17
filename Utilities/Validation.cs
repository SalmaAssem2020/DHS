using System;
using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;

namespace UtilitiesNameSpace
{
    public partial class Utilities
    {
        protected bool IsElementPresent(Element Element)
        {

            try
            {
                if (!driver.driver.FindElement(Element.ByElement).Location.IsEmpty)
                    return true;
                

                else
                    return false;
            }

            catch
            {

                return false;
            }

        }

        protected bool IsElementVisible(Element Element)
        {
            try
            {
                if (driver.driver.FindElement(Element.ByElement).Displayed)
                    return true;

                else
                    return false;
            }

            catch
            {
                return false;
            }
        }

        protected bool IsElementPresentAndVisible(Element Element)
        {

            try
            {
                if (!driver.driver.FindElement(Element.ByElement).Location.IsEmpty)
                {



                    if (IsElementVisible(Element))
                        return true;

                    else
                        return false;
                }

                else
                    return false;
            }

            catch
            {

                return false;
            }

        }

        protected bool IsElementEnabled(Element Element)
        {

            if (driver.driver.FindElement(Element.ByElement).Enabled)
            {
                if (driver.driver.FindElement(Element.ByElement).GetAttribute("disabled") == "true")
                    return false;

                return true;

            }
            else
                return false;
        }

        protected void Page_Should_Contains_Element(double Time, Element Element, string ElementName)
        {

            for (int i = 1; i <= Convert.ToInt32(Time); i++)
            {
                // is that element present at HTML (has a location) and visible
                if (!IsElementPresentAndVisible(Element))
                {
                    if (i == Convert.ToInt32(Time))
                    {
                        Assert.Fail(ElementName + " is not found on page.");

                    }

                    else
                    {
                        Thread.Sleep(1000);

                    }

                }

                else
                {
                    // if element is there, go to the element
                    Move_To_Element(Element);

                    i = Convert.ToInt32(Time);
                }

            }
        }


        protected void Page_Should_Not_Contains_Element(double Time, Element Element, String ElementName)
        {
            Thread.Sleep(TimeSpan.FromSeconds(Time));

            if (IsElementPresent(Element))
            {
               Assert.Fail("Element " + ElementName + " is found in the page.");

                if (IsElementVisible(Element))
                    Assert.Fail("Element " + ElementName + " is visible in the page.");

            }
        }


        protected void ElementValue_IsCorrect(Element Element, string Expected_Text, string ElementName)
        {
            if (driver.driver.FindElement(Element.ByElement).Text.ToLower() == Expected_Text.ToLower()) { }

            else
            {
                Assert.Fail(ElementName + "'s value is not correct as expected " + Expected_Text + " but the actual is " + driver.driver.FindElement(Element.ByElement).Text);
            }



        }


    }
}
