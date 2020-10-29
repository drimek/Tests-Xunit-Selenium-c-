using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestyXunit
{
    class KontaktPage
    {
        IWebDriver _webDriver;


        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div/div[7]/div/div/div/div/div/div[4]/div/div/div/div[1]/div/div/div[3]/div/h3/a")]
        public IWebElement Mediapact { get; set; }

        public string mediapactXPath = "/html/body/div[3]/div/div/div/div[2]/div/div[7]/div/div/div/div/div/div[4]/div/div/div/div[1]/div/div/div[3]/div/h3/a";
        public KontaktPage(IWebDriver driver)
        {
            _webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
