using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SMWebUIAutomation.PageObjects
{
    internal class FunctionConfigPage : BasePage
    {
        public FunctionConfigPage(IWebDriver driver) : base(driver)
        {

        }

        private string URLText;
        protected By SearchBox => By.XPath("//div[@id='FunctionSearch']/input");
        protected By RegisterBtn => By.XPath("(//span[text()='Register and Apply'])[2]");

        public void WaitForElementWithTextDisplayed(string text)
        {
            By element = By.XPath("//*[text()='" + text + "']");
            WaitUntilElementIsVisible(element);
            ThreadSleepWait();
        }

        public void ClickOnElementHavingText(string text)
        {
            By element = By.XPath("//*[text()='" + text + "']");
            WaitUntilElementIsVisible(element);
            ClickOnElement(Driver.FindElement(element));
        }

        public void ClickOnElementContainsText(string text)
        {
            By element = By.XPath("//*[contains(text(),'" + text + "')]");
            WaitUntilElementIsVisible(element);
            ClickOnElement(Driver.FindElement(element));
        }

        public void GetStudentRegistrationURL()
        {
            By URLInfo = By.XPath("(//div[@class='htmlText'])[1]");
            WaitUntilElementIsVisible(URLInfo);
            URLText = Driver.FindElement(URLInfo).Text;
            URLText = URLText[12..];
            Console.WriteLine("Student Registration URL: " + URLText);
        }

        public void NavigateToStudentRegistrationPage()
        {
            Navigate(URLText);
            ThreadSleepWait(8);
            WaitUntilElementIsVisible(RegisterBtn);
        }

    }
}