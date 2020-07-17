using NUnit.Framework;
using System.Threading;
using UtilitiesNameSpace;

namespace DHS
{
    [TestFixture]
    public class Eligibility_Tests
    {
        //Declare Driver
        private Driver driver = new Driver(Browser.Chrome);

        //Declare Needed Pages
        private Login LoginPage;
        private Eligiblity EligibilityPage;

        [OneTimeSetUp]
        public void StartUp()
        {
            LoginPage = new Login(driver);
            EligibilityPage = new Eligiblity(driver);

            //Access DHS and Login
            LoginPage.Navigate_To_LoginPage();

            //Enter Credentials
            LoginPage.Input_UserName(TestingUsers.UserName);
            LoginPage.Input_Password(TestingUsers.Password);
            LoginPage.Click_Submit();

        }

        [SetUp]
        public void Setup()
        {
            //Navigate to Eligibility Page
            EligibilityPage.Navigate_To_Eligibility();


        }

        [Test]
        [TestCaseSource(typeof(Eligiblity_Validations), "Eligibility_Validations_DS")]
        public void Check_EligibilityValidations(bool? availablePayer , string Payer, bool? validNationalId, string NationalId, string Speciality, string SubSpeciality)
        {

            //Input Data
            if(Payer != null)
                EligibilityPage.Select_InsuranceCompany(Payer);

            //If the Payer isnt available, a popup should be displayed
            if (availablePayer == false)
            {
                EligibilityPage.Assert_PayerNotAvailablePopup_IsDisplayed();
                Assert.Pass();
            }

            //Input National Id
            if (NationalId != null)
                EligibilityPage.Input_NationalID(NationalId);

            //Assert the specilaity dropdwon is empty if no payer is selected
            if (Payer == null)
                EligibilityPage.Assert_SpecialityOptions_NotDisplayed();

            //Else, select speciality
            else
            {

                if (Speciality != null)
                {
                    Thread.Sleep(2000);
                    EligibilityPage.Select_Speciality(Speciality);

                    //If speciality is selected, select sub speciality
                    if (SubSpeciality != null)
                    {
                        Thread.Sleep(2000);
                        EligibilityPage.Select_subSpeciality(SubSpeciality);
                    }
                }
            }

            //Click Submit
            EligibilityPage.Click_submitButton();

            //Check Validations if any
            if (Payer == null)
                EligibilityPage.Assert_RequiredPayerError_IsDisplayed();

            if (Speciality == null)
                EligibilityPage.Assert_RequiredSpecialityError_IsDisplayed();

            if (Speciality != null && SubSpeciality == null)
                EligibilityPage.Assert_RequiredSubSpecialityError_IsDisplayed();

            if (NationalId == null)
                EligibilityPage.Assert_RequiredNationalIdError_IsDisplayed();

            if (validNationalId == false)
                EligibilityPage.Assert_InvalidNationalIdError_IsDisplayed();

            //Check Result If All Inputs Are Valid
            if(Payer != null && Speciality != null && SubSpeciality != null && validNationalId == true)
            {
                //Assert Submission is passed and tabs are displayed
                EligibilityPage.Assert_GeneralTab_IsDisplayed();
                EligibilityPage.Assert_MemberTab_IsDisplayed();
                EligibilityPage.Assert_TableOfBenifitsTab_IsDisplayed();
            }

            //Pass the test
            Assert.Pass("Eligibility Submit and Validation Is Working.");

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.TeardownDriver();
        }
    }
}