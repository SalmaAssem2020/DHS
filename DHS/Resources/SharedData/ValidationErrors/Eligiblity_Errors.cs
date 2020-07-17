using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UtilitiesNameSpace;

namespace DHS
{
    public static class Eligiblity_Errors 
    {
        public static string RequiredPayer_Error = "This field is required.";
        public static string RequiredNationalId_Error = "National Identity is Required";
        public static string InvalidNationalId_Error = "Invalid National Identity";
        public static string RequiredSpeciality_Error = "Speciality is Required";
        public static string RequiredSubSpeciality_Error = "Sub Speciality is Required";

    }
}
