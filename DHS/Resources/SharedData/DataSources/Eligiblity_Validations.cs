using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UtilitiesNameSpace;

namespace DHS
{
    public static class Eligiblity_Validations 
    {
        public static IEnumerable<TestCaseData> Eligibility_Validations_DS()
        {
            yield return new TestCaseData(null, null, null, null, null, null).SetName("Check Eligibility with empty fields.");
            yield return new TestCaseData(true, "SAICO", null, null, "Dental", "Dental Hygiene").SetName("Check Eligibility with empty Nationality Id.");
            yield return new TestCaseData(true, "SAICO", true, "2412017531", "Dental", "Dental Hygiene").SetName("Check Eligibility with invalid Nationality Id.");
            yield return new TestCaseData(false, "Al-Ahlia", true, "2412017531", "Dental", "Dental Hygiene").SetName("Check Eligibility with invalid Payer.");
            yield return new TestCaseData(true, "SAICO", true, "2412017531", "Dental", null).SetName("Check Eligibility with Empty sub speciality.");
            yield return new TestCaseData(true, "SAICO", true, "2412017531", "Dental", "Dental Hygiene").SetName("Check Eligibility with valid inputs.");
            

        }

    }
}
