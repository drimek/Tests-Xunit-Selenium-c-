using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestyXunit.Tests;
using Xunit;

namespace TestyXunit
{
    public class TestKlasa : BaseTest
    {


        protected override void SetUp(BrowserType browserType)
        {
            base.SetUp(browserType);

            if (File.Exists(downloadPath + "\\logotypy.zip"))
                File.Delete(downloadPath + "\\logotypy.zip");
        }

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]
        public void DownloadLogotypy(BrowserType browserType)
        {
            SetUp(browserType);

            var mainPage = new MainPage(webDriver);

            bool DidColorChanged=mainPage.VerifyColorChangeAfterMouseMoveOverIt(mainPage.Kontakt);
            mainPage.Kontakt.Click();

            var kontaktPage = new KontaktPage(webDriver);

            webDriver.FindElement(By.Id("cn-accept-cookie")).Click();

            GlobaMethods.ScrollToWebElement(kontaktPage.Mediapact);
            kontaktPage.Mediapact.Click();

            var mediapactPage = new MediaPactPage(webDriver);
            //blocks button
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("qode - page - loading - effect - holder")));
            Wait.Until(webDriver => mediapactPage.Logotypy.Displayed && mediapactPage.Logotypy.Enabled);

            mediapactPage.Logotypy.Click();

            //wait to download
            Task.Delay(10000).Wait();

            Assert.True(DidColorChanged, "Color of kontakty didn't change after mouse move over it");
            Assert.True(File.Exists(downloadPath + "\\logotypy.zip"),"File havent downloaded");

            CleanUp();
        }

    }
}
