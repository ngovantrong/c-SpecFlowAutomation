using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SMWebUIAutomation.PageObjects
{
    internal class MyDetailsPage : BasePage
    {
        public MyDetailsPage(IWebDriver driver) : base(driver)
        {

        }

        protected By ContactsTab => By.Id("Tab_StudentContactsListSection_Handle");
        protected By AddButton => By.Id("StudentContactsListSection_RDP_ActionsExMenu_menuItem0_DDC_DropDownButton");
        protected By ContactTypeInput => By.XPath("//input[@id='StudentOtherContactSection_ContactType']");
        protected By ContactNameInput => By.XPath("//input[@id='StudentOtherContactSection_ContactName']");
        protected By SaveButton => By.Id("StudentOtherContactSection_TopSaveButton");
        protected By GreenSaveBtn => By.XPath("//button[contains(@class,'Saved')]");

        public void ClickContactsSection()
        {
            WaitUntilElementIsVisible(this.ContactsTab);
            ClickOnElement(Driver.FindElement(this.ContactsTab));
        }

        public void ClickAddButton()
        {
            WaitUntilElementIsVisible(this.AddButton);
            ClickOnElement(Driver.FindElement(this.AddButton));
        }

        public void SelectContactType(string text)
        {
            WaitUntilElementIsVisible(this.ContactTypeInput);
            TypeStringIntoElement(Driver.FindElement(this.ContactTypeInput), text);
            Driver.FindElement(this.ContactTypeInput).SendKeys(Keys.Tab);
            ThreadSleepWait();
        }

        public void InputContactName(string text)
        {
            text = text + " " + RandomString(5);
            Console.WriteLine("Contact Name: " + text);
            WaitUntilElementIsVisible(this.ContactNameInput);
            TypeStringIntoElement(Driver.FindElement(this.ContactNameInput), text);
        }

        public void ClickSaveButton()
        {
            WaitUntilElementIsVisible(this.SaveButton);
            ClickOnElement(Driver.FindElement(this.SaveButton));
        }

        public void ClickOnSavedGreenButton()
        {
            WaitUntilElementIsVisible(this.GreenSaveBtn);
            ClickOnElement(Driver.FindElement(this.GreenSaveBtn));
        }

        public void VerifySuccessfullMessage()
        {
            By element = By.CssSelector("span[class='messageText']");
            WaitUntilElementIsVisible(element);
            Assert.AreEqual(Driver.FindElement(element).Text, "Successfully saved.");
        }

    }
}