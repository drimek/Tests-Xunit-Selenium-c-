using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestyXunit.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver webDriver;
        protected Actions Actions { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected GlobalMethods GlobaMethods { set; get; }
        protected readonly string downloadPath = @"C:\Downloads";
        protected string URL = "https://www.medicalgorithmics.pl/";

        protected virtual void SetUp(BrowserType browserType)
        {
            webDriver = WebDriversFactory.GetWebDriver(browserType, downloadPath);
            Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            Actions = new Actions(webDriver);

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(URL);
            GlobaMethods = new GlobalMethods(webDriver);

        }

        protected virtual void CleanUp()
        {
            webDriver.Quit();
        }

    }
}
