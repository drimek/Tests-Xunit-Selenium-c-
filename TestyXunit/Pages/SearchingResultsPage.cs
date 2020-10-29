using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestyXunit.Pages
{
    class SearchingResultsPage
    {
        IWebDriver _webDriver;

        GlobalMethods _globaMethods;

        
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul")]
        public IWebElement SearchResultsContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div[11]/ul")]
        public IWebElement NumberOfSearchPagesContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div[2]/div[2]/div/ul/div[11]/ul/li[3]/a")]
        public IWebElement LastPageNumber { get; set; }

        public SearchingResultsPage(IWebDriver driver)
        {
            _webDriver = driver;
            _globaMethods = new GlobalMethods(_webDriver);
            PageFactory.InitElements(driver, this);
        }

        public int GetNumberOfSearchResults()
        {
            var searchList = SearchResultsContainer.FindElements(By.ClassName("latest_post_custom"));

            return searchList.Count;
        }

        public bool DoesThisResultExists(string result)
        {
            var searchList = SearchResultsContainer.FindElements(By.ClassName("latest_post_custom"));

            var results = SearchResultsContainer.FindElements(By.XPath("//a[@itemprop='url']"));

            var founded=results.FirstOrDefault(x => x.GetAttribute("innerText").Equals(result));

            return founded == null ? false : true;
        }

        public string NumberOfSearchPages()
        {

            return LastPageNumber.GetAttribute("innerText");
        }

    }
}
