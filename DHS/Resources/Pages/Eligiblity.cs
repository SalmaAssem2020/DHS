using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium.Support.PageObjects;
using UtilitiesNameSpace;
using System.Threading;

namespace DHS
{
    public class Eligiblity : Utilities
    {

        public Eligiblity(Driver driver) : base(driver)
        {
            
        }


        #region Page Objects
        private Element select_InsuranceCompany = new Element(LocateBy.Id, LocatorValue: "InsuranceCompanyId");

        private Element div_NotAvailablePayer = new Element(LocateBy.XPath, LocatorValue: "//div[@class='waringimessagdive text-center mb-30']"); 

        private Element button_CloseInvalidPayerPopup = new Element(LocateBy.XPath, LocatorValue: "//button[@class='close btn-danger nencbfb']/i"); 

        private Element input_NationalID = new Element(LocateBy.Id, LocatorValue: "txtNationalID"); 

        private Element span_Speciality  = new Element(LocateBy.Id, LocatorValue: "select2-slctDep-container");

        private Element option_SecondSpecialityOption = new Element(LocateBy.XPath, LocatorValue: "//select[@id='slctDep']/option[2]");

        private Element select_Speciality = new Element(LocateBy.Id, LocatorValue: "slctDep");

        private Element select_SubSpeciality = new Element(LocateBy.Id, LocatorValue: "slctSubDep");

        private Element button_Submit = new Element(LocateBy.Id, LocatorValue: "EligSub");

        private Element span_RequiredInsuranceCompanyErr = new Element(LocateBy.Id, LocatorValue: "InsuranceCompanyId-error");

        private Element span_InvalidNationalIdErr = new Element(LocateBy.Id, LocatorValue: "txtNationalID-error");

        private Element span_RequiredSpecialityErr = new Element(LocateBy.Id, LocatorValue: "slctDep-error");

        private Element span_RequiredSubSpecialityErr = new Element(LocateBy.Id, LocatorValue: "slctSubDep-error");

        private Element a_generalTab = new Element(LocateBy.XPath, LocatorValue: "//a[@data-toggle='tab' and @href='#General']"); 

        private Element a_memberTab = new Element(LocateBy.XPath, LocatorValue: "//a[@data-toggle='tab' and @href='#Member']");

        private Element a_tableOfBenifitsTab = new Element(LocateBy.XPath, LocatorValue: "//a[@data-toggle='tab' and @href='#Treament']");
        #endregion

        public void Navigate_To_Eligibility()
        {
            NavigateToURL(URLs.EligibilityURL);
        }

        public void Select_InsuranceCompany(string Company)
        {
            SelectFromList(select_InsuranceCompany, "Insurance Company Drop Down", Company);
        }

        public void Assert_PayerNotAvailablePopup_IsDisplayed()
        {
            Page_Should_Contains_Element(40, div_NotAvailablePayer, "Not Available Payer");
        }

        public void Click_ClosePayerNotAvaiablePopup()
        {
            Find_And_Click(20, button_CloseInvalidPayerPopup, "Close Payer Not Available Popup.");
        }

        public void Input_NationalID(string NationalId)
        {
            Clear_And_InputValue(20, input_NationalID, NationalId, "National Id");
        }

        public void Click_SpecilaityDropDown()
        {
            Find_And_Click(20, span_Speciality, "Speciality Drop Down Menu");
        }

        public void Assert_SpecialityOptions_NotDisplayed()
        {
            Page_Should_Not_Contains_Element(2, option_SecondSpecialityOption, "Speciality Options");
        }

        public void Select_Speciality(string Speciality)
        {
            SelectFromList(select_Speciality, "Speciality Drop Down", Speciality);
        }

        public void Select_subSpeciality(string subSpeciality)
        {
            SelectFromList(select_SubSpeciality, "Sub Speciality Drop Down", subSpeciality);
        }

        public void Click_submitButton()
        {
            Find_And_Click(20, button_Submit, "Submit Button");
        }

        public void Assert_RequiredPayerError_IsDisplayed()
        {
            Page_Should_Contains_Element(20, span_RequiredInsuranceCompanyErr, "Required Payer Error");

            ElementValue_IsCorrect(span_RequiredInsuranceCompanyErr, Eligiblity_Errors.RequiredPayer_Error, "Required Payer Error");
        }

        public void Assert_RequiredNationalIdError_IsDisplayed()
        {
            Page_Should_Contains_Element(20, span_InvalidNationalIdErr, "Required National Id Error");

            ElementValue_IsCorrect(span_InvalidNationalIdErr, Eligiblity_Errors.RequiredNationalId_Error, "Required National Id Error");
        }

        public void Assert_InvalidNationalIdError_IsDisplayed()
        {
            Page_Should_Contains_Element(20, span_InvalidNationalIdErr, "Invalid National Id Error");

            ElementValue_IsCorrect(span_InvalidNationalIdErr, Eligiblity_Errors.InvalidNationalId_Error, "Invalid National Id Error");
        }

        public void Assert_RequiredSpecialityError_IsDisplayed()
        {
            Page_Should_Contains_Element(20, span_RequiredSpecialityErr, "Required Speciality Error");

            ElementValue_IsCorrect(span_RequiredSpecialityErr, Eligiblity_Errors.RequiredSpeciality_Error, "Required Speciality Error");
        }

        public void Assert_RequiredSubSpecialityError_IsDisplayed()
        {
            Page_Should_Contains_Element(20, span_RequiredSubSpecialityErr, "Required Sub Speciality Error");

            ElementValue_IsCorrect(span_RequiredSubSpecialityErr, Eligiblity_Errors.RequiredSubSpeciality_Error, "Required Sub Speciality Error");
        }

        public void Assert_GeneralTab_IsDisplayed()
        {
            Page_Should_Contains_Element(20, a_generalTab, "General Tab");
        }

        public void Assert_MemberTab_IsDisplayed()
        {
            Page_Should_Contains_Element(20, a_memberTab, "Member Tab");
        }

        public void Assert_TableOfBenifitsTab_IsDisplayed()
        {
            Page_Should_Contains_Element(20, a_tableOfBenifitsTab, "Table Of Benifits Tab");
        }
    }
}
