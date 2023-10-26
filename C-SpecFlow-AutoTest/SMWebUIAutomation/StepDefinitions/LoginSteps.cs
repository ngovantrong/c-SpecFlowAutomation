using SMWebUIAutomation.PageObjects;
using SMWebUIAutomation.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SMWebUIAutomation.StepDefinitions
{
    [Binding]

    public sealed class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
        }

        [Given(@"user navigates to the SM website")]
        public void GivenUserNavigatesToTheFINWebsite()
        {
            _loginPage.Navigate(TestConfiguration.GetSectionAndValue("Settings", "URL"));
        }

        [Given(@"user navigates to the SM student website")]
        public void GivenUserNavigatesToTheSMStudentWebsite()
        {
            _loginPage.Navigate(TestConfiguration.GetSectionAndValue("Settings", "Student_URL"));
        }


        [When(@"user enters username and password")]
        public void WhenUserEntersUsernameAndPassword(Table table)
        {
            dynamic credentials = table.CreateDynamicInstance();
            _loginPage.InputUsernamePassword((string)credentials.username, (string)credentials.password);
        }

        [When(@"user enters username and password for student login")]
        public void WhenUserEntersUsernameAndPasswordForStudentLogin(Table table)
        {
            dynamic credentials = table.CreateDynamicInstance();
            int username1 = credentials.username;
            string username2 = (username1 + 0).ToString();
            _loginPage.InputUsernamePassword(username2, (string)credentials.password);
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

        [Then(@"user log out from SM website")]
        public void ThenUserLogOutFromFINWebsite()
        {
            _loginPage.DoLogout();
        }

        [Then(@"user verify error message displayed '(.*)'")]
        public void ThenUserVerifyErrorMessageDisplayed(string text)
        {
            _loginPage.VerifyErrorMessageDisplayed(text);
        }


    }

}
