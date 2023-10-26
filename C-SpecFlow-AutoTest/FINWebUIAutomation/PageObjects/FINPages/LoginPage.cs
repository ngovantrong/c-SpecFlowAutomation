using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FINWebUIAutomation.PageObjects
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        protected By UsernameField => By.Id("LogonName");
        protected By PasswordField => By.Id("Password");
        protected By ForgotPassword => By.Id("BtnChgPwd");
        protected By LogOnBtn => By.Id("BtnLogOn");
        protected By LoggedUser => By.XPath("//*[@class='name']");
        protected By LogOffBtn => By.XPath("//a[text()='Log Off']");
        protected By searchField => By.XPath("//div[@id='FunctionSearch']/input");

        public void InputUsernamePassword(string username, string password)
        {
            TypeStringIntoElement(Driver.FindElement(this.UsernameField), username);
            TypeStringIntoElement(Driver.FindElement(this.PasswordField), password);
        }

        public void ClickLogOnbutton()
        {
            ClickOnElement(Driver.FindElement(this.LogOnBtn));
        }

        public void VeriyPageTitle(string expected_title)
        {
            string actual_title = GetPageTitle();
            Assert.AreEqual(expected_title, actual_title);
        }

        public void VerifySearchFieldDisplayed()
        {
            WaitUntilElementClickable(Driver.FindElement(this.searchField));
        }

        public void DoLogout()
        {
            ClickOnElement(Driver.FindElement(this.LoggedUser));
            ClickOnElement(Driver.FindElement(this.LogOffBtn));

        }

    }
}