using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using FINWebUIAutomation.Support;

namespace FINWebUIAutomation.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        private WebDriverWait wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void CloseBrowser()
        {
            Driver.Close();
        }

        public string GetPageUrl()
        {
            return Driver.Url;
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public string RandomString(int length = 3)
        {
            Random random = new();
            var rString = "";

            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            return rString;
        }

        public string CurrentDate()
        {
            var date = DateTime.Today;
            var currentdate = date.Date.ToString("dd-MM-yyyy");
            return currentdate;
        }

        public string CurrentDateTime()
        {
            string dateTimeFormat = (DateTime.Now).ToString("dd/MM/yy HH:mm");
            return dateTimeFormat;
        }

        public void WaitUntilDocumentIsReady(int timeout = 30)
        {
            var javaScriptExecutor = Driver as IJavaScriptExecutor;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(
                    wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
            }
            catch (Exception e)
            {
                Console.WriteLine("The exception found: " + e.Message);
            }
        }

        public void WaitUntilElementClickable(IWebElement webelement, int timeout = 30)
        {
            var javaScriptExecutor = Driver as IJavaScriptExecutor;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(
                    wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
                wait.Until(ExpectedConditions.ElementToBeClickable(webelement));
            }
            catch (Exception e)
            {
                Console.WriteLine("WaitUntilElementClickable. The exception found: " + e.Message);
            }
        }

        public void WaitUntilElementIsVisible(By webelement, int timeout = 30)
        {
            var javaScriptExecutor = Driver as IJavaScriptExecutor;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(
                    wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
                wait.Until(ExpectedConditions.ElementIsVisible(webelement));
            }
            catch (Exception e)
            {
                Console.WriteLine("WaitUntilElementIsVisible. The exception found: " + e.Message);
            }
        }

        public void WaitUntilElementNotVisible(By webelement, int timeout = 30)
        {
            var javaScriptExecutor = Driver as IJavaScriptExecutor;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(
                    wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(webelement));
            }
            catch (Exception e)
            {
                Console.WriteLine("The exception found: " + e.Message);
            }
        }

        public void ClickOnElement(IWebElement element)
        {
            WaitUntilElementClickable(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void ClearTextInElement(IWebElement element)
        {
            WaitUntilElementClickable(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", element);
            element.Clear();
        }

        public void ForceClearTextInElement(IWebElement element)
        {
            element.Click();
            element.SendKeys(Keys.LeftControl + "a");
            element.SendKeys(Keys.Backspace);
        }

        public void MoveToElement(IWebElement element)
        {
            WaitUntilElementClickable(element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void TypeStringIntoElement(IWebElement element, string text)
        {
            ClearTextInElement(element);
            ClickOnElement(element);
            element.SendKeys(text);
        }

        public static void ThreadSleepWait(int seconds = 2)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void DeleteFileInFolder(string fileName, string folder)
        {
            string path = FileSupport.GetCompleteFilePath(folder + "\\");
            string[] filePaths = Directory.GetFiles(path);

            foreach (string p in filePaths)
            {
                if (p.Contains(fileName))
                {
                    File.Delete(p);
                    Console.WriteLine("Deleted file: " + p);
                    break;
                }
            }
        }
    }
}