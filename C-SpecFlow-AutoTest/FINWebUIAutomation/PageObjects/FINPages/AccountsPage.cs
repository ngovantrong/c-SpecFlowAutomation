using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FINWebUIAutomation.PageObjects
{
    internal class AccountsPage : BasePage
    {
        public AccountsPage(IWebDriver driver) : base(driver)
        {

        }

        protected By HeaderChartName => By.Id("Header_ChartName");
        protected By ChartNameInputField => By.Id("Contextual_ChartName");
        protected By ClearChartNameBtn => By.CssSelector("div[class='inputClearButton']");
        protected By OKButton => By.Id("ContextualKeysOkButton");
        protected By AddButton => By.XPath("//button[@title='Add']");
        protected By NewAccountBtn => By.XPath("//button[@title='Add']/following::a[@class='link']");
        protected By DirectDebitAccount => By.Id("DirectDebit");
        protected By SaveBtn => By.Id("AddSection_TopSaveButton_DefaultButton");
        protected By EditBtn => By.Id("ChartAccountGeneralSection_TopEditButton");
        protected By DropdownBtn => By.Id("MoreActions_DropDownButton");
        protected By DeleteOption => By.XPath("//span[text()='Delete']");


        public void ClickHeaderChartName()
        {
            WaitUntilElementIsVisible(this.HeaderChartName);
            ClickOnElement(Driver.FindElement(this.HeaderChartName));
        }

        public void FilterChartName(string text)
        {
            ClickOnElement(Driver.FindElement(this.ClearChartNameBtn));
            TypeStringIntoElement(Driver.FindElement(this.ChartNameInputField), text.ToLower());
            By matchingChartname = By.XPath("//td[text()='" + text + "']");
            WaitUntilElementIsVisible(matchingChartname);
            ClickOnElement(Driver.FindElement(matchingChartname));
            ThreadSleepWait();
            ClickOnElement(Driver.FindElement(this.OKButton));
            ThreadSleepWait(10);
        }

        public void ClickAddButton()
        {
            ClickOnElement(Driver.FindElement(this.AddButton));
        }

        public void SelectAccountType()
        {
            WaitUntilElementIsVisible(NewAccountBtn);
            ClickOnElement(Driver.FindElement(this.NewAccountBtn));
            ClickOnElement(Driver.FindElement(this.DirectDebitAccount));
            WaitUntilElementIsVisible(By.XPath("//div[text()='Add Direct Debit Debtor']"));
        }

        public void InputInfoToGivenFieldName(string text, string locator)
        {
            By element = By.XPath("//*[text()='" + locator + "']/following::input[1]");
            if (locator.Equals("Account"))
                element = By.Id("BankAccount");
            TypeStringIntoElement(Driver.FindElement(element), text);
            Driver.FindElement(element).SendKeys(Keys.Tab);
            ThreadSleepWait(3);
        }

        public void ClickSaveButton()
        {
            ClickOnElement(Driver.FindElement(this.SaveBtn));
            WaitUntilElementIsVisible(EditBtn);
        }

        public void PerformDeleteAccount()
        {
            ClickOnElement(Driver.FindElement(this.DropdownBtn));
            ClickOnElement(Driver.FindElement(this.DeleteOption));
            ClickOnElement(Driver.FindElement(By.Id("Popup0_popupOk")));
            WaitUntilElementNotVisible(By.CssSelector("div[class*='durationSpinner hasCancelButton']"));
        }
    }
}