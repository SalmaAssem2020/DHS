using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UtilitiesNameSpace;

namespace DHS
{
    public static class URLs 
    {
        public static string LoginURL = "http://devfauth.dhsarabia.com.sa:9011/oauth2/authorize?client_id=af861d39-8fa9-4a64-8f11-b64dddf929dc&response_type=code&redirect_uri=https%3A%2F%2Fplatform-test.dhsarabia.com.sa";
        public static string EligibilityURL = "https://platform-test.dhsarabia.com.sa/Eligiblity";

    }
}
