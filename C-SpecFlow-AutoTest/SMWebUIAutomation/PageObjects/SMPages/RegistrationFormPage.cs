using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SMWebUIAutomation.PageObjects
{
    internal class RegistrationFormPage : BasePage
    {
        public RegistrationFormPage(IWebDriver driver) : base(driver)
        {

        }

        protected By familyNameField = By.Id("FamilyName");
        protected By givenNameField = By.Id("GivenName");
        protected By dobField = By.Id("BirthDate");
        protected By emailField = By.XPath("//input[@id='EmailAddress']");
        protected By nationalityField = By.Id("Nationality");
        protected By TermAndConCheckBox = By.XPath("//*[@id='HasAgreedToTermsAndConditions']/parent::div");
        protected By RegisterBtn = By.XPath("(//button[@title='Register and Apply'])[2]");
        protected By SuccessMessage = By.XPath("(//div[@class='plainText'])[1]");


        public void InputFamilyNameInfo(string inputtext)
        {
            Console.WriteLine("Input to family name: " + inputtext);
            WaitUntilElementIsVisible(familyNameField);
            TypeStringIntoElement(Driver.FindElement(familyNameField), inputtext);
        }

        public void InputGivenNameInfo(string inputtext)
        {
            Console.WriteLine("Input to given name: " + inputtext);
            WaitUntilElementIsVisible(givenNameField);
            TypeStringIntoElement(Driver.FindElement(givenNameField), inputtext);
        }

        public void InputDateOfBirthInfo(string inputdate)
        {
            Console.WriteLine("Input to date of birth field: " + inputdate);
            WaitUntilElementIsVisible(dobField);
            TypeStringIntoElement(Driver.FindElement(dobField), inputdate);
            Driver.FindElement(dobField).SendKeys(Keys.Tab);
            ThreadSleepWait(5);
        }

        public void InputEmailInfo(string emailprefix, string text)
        {
            string full_email = "<" + emailprefix + RandomString(10) + "@technologyonecorp.com" + ">" + text;
            Console.WriteLine("Input to email field: " + full_email);
            WaitUntilElementIsVisible(emailField);
            TypeStringIntoElement(Driver.FindElement(emailField), full_email);
            Driver.FindElement(emailField).SendKeys(Keys.Tab);
            ThreadSleepWait(5);
        }

        public void InputNationalityInfo(string inputtext)
        {
            Console.WriteLine("Input to nationality field: " + inputtext);
            WaitUntilElementIsVisible(nationalityField);
            TypeStringIntoElement(Driver.FindElement(nationalityField), inputtext);
            Driver.FindElement(emailField).SendKeys(Keys.Tab);
            ThreadSleepWait(5);
        }

        public void ClickTermAndConditionCheckBox()
        {
            WaitUntilElementIsVisible(TermAndConCheckBox);
            ClickOnElement(Driver.FindElement(TermAndConCheckBox));
            ThreadSleepWait();
        }

        public void ClickRegisterButton()
        {
            ClickOnElement(Driver.FindElement(RegisterBtn));
        }

        public void VerifySuccessMessage()
        {
            string exp_message = "Thank you for registering! Please check your email...";
            WaitUntilElementIsVisible(SuccessMessage);
            Assert.AreEqual(exp_message, Driver.FindElement(SuccessMessage).Text);
        }
    }
}