using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestyXunit
{
    public class GlobalMethods
    {
        WebDriverWait _wait;
        IWebDriver webDriver;
        public GlobalMethods(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(7));
        }

        public void ScrollToWebElement(IWebElement element)
        {
            _wait.Until(webDriver => { ((IJavaScriptExecutor)webDriver).ExecuteScript("window.scrollBy(0,500)"); return element.Displayed && element.Enabled; });
        }

        public void ScrollToWebElement(string xPath)
        {
            _wait.Until(webDriver => { ((IJavaScriptExecutor)webDriver).ExecuteScript("window.scrollBy(0,500)"); 
                                        return webDriver.FindElement(By.XPath(xPath)).Displayed && webDriver.FindElement(By.XPath(xPath)).Enabled; });
        }


    }
}
