using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestyXunit
{

    public enum BrowserType
    {
        Chrome,
        Firefox
    }

    class WebDriversFactory
    {

        public static IWebDriver GetWebDriver(BrowserType browserType, string dowloadDirectory= @"C:\Downloads")
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("download.default_directory", dowloadDirectory);
                    return new ChromeDriver(options);

                case BrowserType.Firefox:
                    var profile = new FirefoxOptions();
                    profile.SetPreference("browser.download.manager.showWhenStarting", false);
                    profile.SetPreference("browser.download.manager.showAlertOnComplete", false);
                    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip");
                    profile.SetPreference("browser.download.folderList", 2);
                    profile.SetPreference("browser.download.dir", dowloadDirectory);
                    return new FirefoxDriver(profile);

                default:
                    throw new Exception(browserType.ToString()+" Browser Type isn't implemented");
            }
        }



    }
}
