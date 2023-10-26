using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FINWebUIAutomation.PageObjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        protected By SearchBox => By.XPath("//div[@id='FunctionSearch']/input");

        public void SearchForText(string searchText)
        {
            TypeStringIntoElement(Driver.FindElement(this.SearchBox), searchText);
        }

        public void ClickOnFunctionWithName(string text)
        {
            By element = By.XPath("//span[text()='" + text + "']");
            ClickOnElement(Driver.FindElement(element));
            ThreadSleepWait(5);
        }

        public void WaitForElementWithTextDisplayed(string text)
        {
            By element = By.XPath("//*[text()='" + text + "']");
            WaitUntilElementIsVisible(element);
            ThreadSleepWait();
        }

        public void ClickOnRole(string text)
        {
            By element = By.XPath("//*[text()='Roles']/following::mark[text()='" + text + "'][1]");
            WaitUntilElementIsVisible(element);
            ClickOnElement(Driver.FindElement(element));
        }

        public void ClickOnAccountType(string text)
        {
            By element = By.XPath("//a[@aria-description='" + text + "']");
            WaitUntilElementIsVisible(element);
            ClickOnElement(Driver.FindElement(element));
        }


    }
}