using FINWebUIAutomation.PageObjects;
using FINWebUIAutomation.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FINWebUIAutomation.StepDefinitions
{
    [Binding]

    public sealed class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
        }

        [Given(@"user navigates to the FIN website")]
        public void GivenUserNavigatesToTheFINWebsite()
        {
            _loginPage.Navigate(TestConfiguration.GetSectionAndValue("Settings", "URL"));
        }


        [When(@"user enters username and password")]
        public void WhenUserEntersUsernameAndPassword(Table table)
        {
            dynamic credentials = table.CreateDynamicInstance();
            _loginPage.InputUsernamePassword((string)credentials.username, (string)credentials.password);
        }


        [When(@"user clicks Log On button")]
        public void WhenUserClicksLogOnButton()
        {
            _loginPage.ClickLogOnbutton();
        }

        [When(@"user verify page title after logged in is '(.*)'")]
        public void WhenUserVerifyPageTitleAfterLoggedInIs(string text)
        {
            _loginPage.VeriyPageTitle(text);
        }

        [When(@"user verify enterprise search field is displayed")]
        public void WhenUserVerifyEnterpriseSearchFieldIsDisplayed()
        {
            _loginPage.VerifySearchFieldDisplayed();
        }

        [Then(@"user log out from FIN website")]
        public void ThenUserLogOutFromFINWebsite()
        {
            _loginPage.DoLogout();
        }


    }

}
