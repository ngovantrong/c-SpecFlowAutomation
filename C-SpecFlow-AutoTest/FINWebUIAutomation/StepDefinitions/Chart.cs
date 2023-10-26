using FINWebUIAutomation.PageObjects;
using FINWebUIAutomation.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FINWebUIAutomation.StepDefinitions
{
    [Binding]

    public sealed class ChartSteps
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly AccountsPage _accountsPage;

        public ChartSteps(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
            _homePage = new HomePage(driver);
            _accountsPage = new AccountsPage(driver);
        }

        [When(@"user search for '(.*)'")]
        public void WhenUserSearchFor(string p0)
        {
            _homePage.WaitForElementWithTextDisplayed("Expense Stp Transactions");
            _homePage.SearchForText(p0);
        }

        [When(@"user clicks on role '(.*)'")]
        public void WhenUserClicksOnRole(string p0)
        {
            _homePage.ClickOnRole(p0);
        }

        [When(@"user clicks on account type '(.*)'")]
        public void WhenUserClicksOnAcountType(string p0)
        {
            _homePage.ClickOnAccountType(p0);
        }

        [When(@"user filter and select chart '(.*)'")]
        public void WhenUserFilterAndSelectChart(string p0)
        {
            _accountsPage.ClickHeaderChartName();
            _accountsPage.FilterChartName(p0);
        }

        [When(@"user adds new account Direct Debit Account")]
        public void WhenUserAddsNewAccountDirectDebitAccount()
        {
            _accountsPage.ClickAddButton();
            _accountsPage.SelectAccountType();
        }


        [When(@"user input '(.*)' to field '(.*)'")]
        public void WhenUserInputToField(string p0, string p1)
        {
            _accountsPage.InputInfoToGivenFieldName(p0, p1);
        }

        [When(@"user clicks Save button")]
        public void WhenUserClicksSaveButton()
        {
            _accountsPage.ClickSaveButton();
        }

        [Then(@"user perform delete new created account data")]
        public void ThenUserPerformDeleteNewCreatedAccountData()
        {
            _accountsPage.PerformDeleteAccount();
        }


    }

}
