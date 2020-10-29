using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestyXunit
{
    class MediaPactPage
    {
        IWebDriver _webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div/div/div[1]/div/div/div/div[2]/div/div/div[1]/div/h1/a")]
        public IWebElement Logotypy { get; set; }

        public MediaPactPage(IWebDriver driver)
        {
            _webDriver = driver;
           PageFactory.InitElements(driver, this);
        }

    }
}
