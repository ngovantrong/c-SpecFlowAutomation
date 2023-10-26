using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SMWebUIAutomation.PageObjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        protected By SearchBox => By.XPath("//div[@id='FunctionSearch']/input");
        protected By MyDetailsIcon => By.XPath("//a[@aria-description='My Details']");

        public void SearchForText(string searchText)
        {
            TypeStringIntoElement(Driver.FindElement(SearchBox), searchText);
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

        public void ClickMyDetailsIcon()
        {
            WaitUntilElementIsVisible(this.MyDetailsIcon);
            ClickOnElement(Driver.FindElement(this.MyDetailsIcon));
        }

    }
}