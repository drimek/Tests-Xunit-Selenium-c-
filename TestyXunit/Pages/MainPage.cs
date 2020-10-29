using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestyXunit
{
    class MainPage
    {
        IWebDriver _webDriver;
        
        GlobalMethods _globaMethods;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/div/div/nav[1]/div/ul/li[4]/a")]
        public IWebElement Kontakt { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/div/div/nav[1]/div/ul/li[1]/a")]
        public IWebElement ONas { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/div/div/nav[1]/div/ul/li[2]/a")]
        public IWebElement Produkty { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/div/div/nav[1]/div/ul/li[3]/a")]
        public IWebElement Inwestorzy { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div[1]/div/div/div/div/div/div/div[1]/div/h1")]
        public IWebElement MedicalgorithmicsWLiczbach { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div/div[3]/div/div/div/div/div/div[1]/div/div/div/div/div/div/div[1]/div/h2")]
        public IWebElement OstatnieAktualnosci { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div/div[3]/div/div/div/div/div/div[2]/div/div/div/div/div/div/div[1]/div/h2")]
        public IWebElement NajnowszeOfertyPracy { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div/div[4]/div/div/div/div/div/div[1]/div/div/div/div/div/div/div[1]/div/h2")]
        public IWebElement Newsroom { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/div/div/div[2]/div/div/a")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/form/div/div/input")]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/header/div/form/div/div/a")]
        public IWebElement SearchSubmit { get; set; }

        
        public MainPage(IWebDriver driver)
        { 
            _webDriver = driver;
            _globaMethods = new GlobalMethods(_webDriver);
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyColorChangeAfterMouseMoveOverIt(IWebElement element)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            Actions actions = new Actions(_webDriver);
           
            string defaultColor = element.GetCssValue("color");
            actions.MoveToElement(element);
            actions.Perform();
            return wait.Until(webDriver => { var newColor = element.GetCssValue("color"); return !newColor.Equals(defaultColor); });
        }

        public MainPage VerifyWebsiteLoadedCorectly()
        {
            
            _globaMethods.ScrollToWebElement(Produkty);
            Assert.Equal("PRODUKTY", Produkty.GetAttribute("innerText"));

            _globaMethods.ScrollToWebElement(Inwestorzy);
            Assert.Equal("INWESTORZY", Inwestorzy.GetAttribute("innerText"));

            _globaMethods.ScrollToWebElement(Kontakt);
            Assert.Equal("KONTAKT", Kontakt.GetAttribute("innerText"));
            
            _globaMethods.ScrollToWebElement(MedicalgorithmicsWLiczbach);
            Assert.Equal("Medicalgorithmics w liczbach", MedicalgorithmicsWLiczbach.GetAttribute("innerText"));

            _globaMethods.ScrollToWebElement(OstatnieAktualnosci);
            Assert.Equal("Ostatnie aktualności", OstatnieAktualnosci.GetAttribute("innerText"));

            _globaMethods.ScrollToWebElement(NajnowszeOfertyPracy);
            Assert.Equal("Najnowsze oferty pracy", NajnowszeOfertyPracy.GetAttribute("innerText"));
            
            _globaMethods.ScrollToWebElement(Newsroom);
            Assert.Equal("Newsroom", Newsroom.GetAttribute("innerText"));

            return this;
        }


        public MainPage Search(string what)
        {
            SearchButton.Click();

            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));

            wait.Until(_webDriver => SearchInput.Enabled && SearchInput.Displayed);

            SearchInput.SendKeys(what);

            Task.Delay(500).Wait();
            SearchSubmit.Click();

            return this;
        }

    }
}
