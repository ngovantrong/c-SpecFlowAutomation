using System;
using System.IO;
using System.Reflection;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using FINWebUIAutomation.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace FINWebUIAutomation.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {

        private readonly IObjectContainer _objectContainer;
        public IWebDriver _driver;


        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            GetDriver();
            _objectContainer.RegisterInstanceAs(_driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Dispose();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(stepName);
                        break;
                    case "When":
                        _scenario.CreateNode<When>(stepName);
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(stepName);
                        break;
                    case "And":
                        _scenario.CreateNode<And>(stepName);
                        break;
                }
            }
            else
            {
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot(scenarioContext)).Build());
                        break;
                    case "When":
                        _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot(scenarioContext)).Build());
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot(scenarioContext)).Build());
                        break;
                    case "And":
                        _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot(scenarioContext)).Build());
                        break;
                }
            }
        }

        /// <summary>
        /// Take screenshot of the page when test script is failing
        /// </summary>
        /// <param name="scenarioContext"></param>
        private string TakeScreenshot(ScenarioContext scenarioContext)
        {
            string ssLocation;
            try
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ssLocation = Path.Combine(Environment.CurrentDirectory, $"{scenarioContext.ScenarioInfo.Title}.png");
                ss.SaveAsFile(ssLocation, ScreenshotImageFormat.Png);

                TestContext.AddTestAttachment(ssLocation, scenarioContext.ScenarioInfo.Description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return ssLocation;
        }

        /// <summary>
        /// Create and initialize driver
        /// </summary>
        /// <returns></returns>

        public IWebDriver GetDriver()
        {
            // Get browser to be used for testing from appsettings.json
            var browser = TestConfiguration.GetSectionAndValue("BrowserOptions", "Browser");
            if (_driver == null)
            {
                switch (browser)
                {
                    case "chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--window-size=1920,1080");
                        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                        chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                        chromeOptions.AddUserProfilePreference("download.default_directory", FileSupport.GetCompleteFilePath(TestConfiguration.GetSectionAndValue("Path", "downloads")));

                        // Get value for headless option from appsettings.json
                        var headless = TestConfiguration.GetSectionAndValue("BrowserOptions", "Headless");

                        if (headless == "true")
                        {
                            chromeOptions.AddArgument("--headless");
                        }

                        _driver = new ChromeDriver(chromeOptions);

                        break;

                    case "firefox":
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArgument("--window-size=1920,1080");

                        var foxheadless = TestConfiguration.GetSectionAndValue("BrowserOptions", "foxHeadless");

                        if (foxheadless == "true")
                        {
                            firefoxOptions.AddArgument("--headless");
                        }

                        _driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), firefoxOptions);
                        break;
                }

                try
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs(_driver);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Driver failed to initialize");
                }
            }
            return _driver;
        }
    }
}