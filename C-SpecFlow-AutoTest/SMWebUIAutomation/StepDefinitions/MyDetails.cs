using SMWebUIAutomation.PageObjects;
using SMWebUIAutomation.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SMWebUIAutomation.StepDefinitions
{
    [Binding]

    public sealed class MyDetails
    {
        private readonly HomePage _homePage;
        private readonly FunctionConfigPage _functionConfigPage;
        private readonly RegistrationFormPage _registerPage;
        private readonly MyDetailsPage _myDetailsPage;

        public MyDetails(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _functionConfigPage = new FunctionConfigPage(driver);
            _registerPage = new RegistrationFormPage(driver);
            _myDetailsPage = new MyDetailsPage(driver);
        }

        [When(@"user clicks on My Details")]
        public void WhenUserClicksOnMyDetails()
        {
            _homePage.ClickMyDetailsIcon();
        }


        [When(@"user clicks on Contacts section")]
        public void WhenUserClicksOnContactsSection()
        {
            _myDetailsPage.ClickContactsSection();
        }

        [When(@"user clicks on Add button")]
        public void WhenUserClicksOnAddButton()
        {
            _myDetailsPage.ClickAddButton();
        }

        [When(@"user selects Contact Type as '(.*)'")]
        public void WhenUserSelectsContactTypeAs(string p0)
        {
            _myDetailsPage.SelectContactType(p0);
        }

        [When(@"user input Contact Name as '(.*)'")]
        public void WhenUserInputContactNameAs(string p0)
        {
            _myDetailsPage.InputContactName(p0);
        }

        [When(@"user clicks on Save button")]
        public void WhenUserClicksOnSaveButton()
        {
            _myDetailsPage.ClickSaveButton();
        }

        [Then(@"user verifies new contact is saved successfully")]
        public void ThenUserVerifiesNewContactIsSavedSuccessfully()
        {
            _myDetailsPage.ClickOnSavedGreenButton();
            _myDetailsPage.VerifySuccessfullMessage();
        }


    }

}
