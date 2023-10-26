using SMWebUIAutomation.PageObjects;
using SMWebUIAutomation.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SMWebUIAutomation.StepDefinitions
{
    [Binding]

    public sealed class StudentRegistrationSteps
    {
        private readonly HomePage _homePage;
        private readonly FunctionConfigPage _functionConfigPage;
        private readonly RegistrationFormPage _registerPage;

        public StudentRegistrationSteps(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _functionConfigPage = new FunctionConfigPage(driver);
            _registerPage = new RegistrationFormPage(driver);
        }

        [When(@"user search for '(.*)'")]
        public void WhenUserSearchFor(string p0)
        {
            _homePage.WaitForElementWithTextDisplayed("Welcome to your new CiA workplace");
            _homePage.SearchForText(p0);
        }

        [When(@"user clicks on function '(.*)'")]
        public void WhenUserClicksOnFunction(string p0)
        {
            _homePage.ClickOnFunctionWithName(p0);
        }

        [When(@"user waits until element with text '(.*)' to be displayed")]
        public void WhenUserWaitsUntilElementWithTextToBeDisplayed(string p0)
        {
            _functionConfigPage.WaitForElementWithTextDisplayed(p0);
        }

        [When(@"user clicks on '(.*)'")]
        public void WhenUserClicksOn(string p0)
        {
            _functionConfigPage.ClickOnElementHavingText(p0);
            BasePage.ThreadSleepWait();
        }

        [When(@"user clicks on element contains text '(.*)'")]
        public void WhenUserClicksOnElementContainsText(string p0)
        {
            _functionConfigPage.ClickOnElementContainsText(p0);
            BasePage.ThreadSleepWait();
        }


        [When(@"user gets the URL for student application registration")]
        public void WhenUserGetsTheURLForStudentApplicationRegistration()
        {
            _functionConfigPage.GetStudentRegistrationURL();
        }

        [When(@"user navigates to student registration page")]
        public void WhenUserNavigatesToStudentRegistrationPage()
        {
            _functionConfigPage.NavigateToStudentRegistrationPage();
        }

        [When(@"user input all required info to the form")]
        public void WhenUserInputAllRequiredInfoToTheForm(Table table)
        {
            dynamic inputdata = table.CreateDynamicInstance();
            _registerPage.InputFamilyNameInfo((string)inputdata.familyName);
            _registerPage.InputGivenNameInfo((string)inputdata.givenName);
            _registerPage.InputDateOfBirthInfo("01-Jan-1990");
            _registerPage.InputEmailInfo((string)inputdata.emailPrefix, (string)inputdata.givenName);
            _registerPage.InputNationalityInfo((string)inputdata.nationality);
            _registerPage.ClickTermAndConditionCheckBox();
        }

        [When(@"user clicks on Register and Apply button")]
        public void WhenUserClicksOnRegisterAndApplyButton()
        {
            _registerPage.ClickRegisterButton();
        }

        [Then(@"user verifies student registered successfully")]
        public void ThenUserVerifiesStudentRegisteredSuccessfully()
        {
            _registerPage.VerifySuccessMessage();
        }

        [When(@"user waits for '(.*)' seconds")]
        public void WhenUserWaitsForSeconds(int p0)
        {
            BasePage.ThreadSleepWait(p0);
        }

    }

}
