using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestyXunit.Pages;
using Xunit;

namespace TestyXunit.Tests
{
    public class SearchTests:BaseTest
    {

        [Theory]
        [InlineData(BrowserType.Chrome)]
        [InlineData(BrowserType.Firefox)]
        public void SearchTest_Pocket_ECG_CRS(BrowserType browserType)
        {
            SetUp(browserType);

            var mainPage = new MainPage(webDriver);

            mainPage.VerifyWebsiteLoadedCorectly();

            mainPage.Search("Pocket ECG CRS");

            var searchResultsPage = new SearchingResultsPage(webDriver);

            Assert.Equal(10, searchResultsPage.GetNumberOfSearchResults());
            Assert.True(searchResultsPage.DoesThisResultExists("PocketECG CRS – telerehabilitacja kardiologiczna"));
            Assert.Equal("2",searchResultsPage.NumberOfSearchPages());

            CleanUp();
        }



    }
}
