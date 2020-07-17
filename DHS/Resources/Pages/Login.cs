using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UtilitiesNameSpace;

namespace DHS
{
    public class Login : Utilities
    {

        public Login(Driver driver) : base(driver)
        { }


        #region Page Objects
        private Element input_Login = new Element(LocateBy.Name, LocatorValue: "loginId");

private Element input_Password = new Element(LocateBy.Name, LocatorValue: "password");

        private Element button_Submit = new Element(LocateBy.Id, LocatorValue: "icon-arrow");


        #endregion

        public void Navigate_To_LoginPage()
        {
            NavigateToURL(URLs.LoginURL);
        }

        public void Input_UserName(string UserName)
        {
            Clear_And_InputValue(20, input_Login, UserName, "Login Text box");
        }

        public void Input_Password(string Password)
        {
            Clear_And_InputValue(20, input_Password, Password, "Password Text box");
        }

        public void Click_Submit()
        {
            Find_And_Click(20, button_Submit, "Submit Button");
        }



    }
}
