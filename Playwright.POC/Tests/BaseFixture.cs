using System;
using Microsoft.Playwright;
using Playwright.POC.Browsers;
using Playwright.POC.Profiles;

namespace Playwright.POC.Tests
{
    public class BaseFixture : IDisposable
    {
        //public readonly PageLoader PageLoader;
        
        public readonly ITestProfile Profile;
        public readonly IBrowser Browser;

        public BaseFixture()
        {
            //PageLoader = new PageLoader();
            Profile = TestProfileFactory.GetDefaultProfile();
            Browser = BrowserFactory.LaunchBrowser().Result;
        }

        public void Dispose()
        {
            Browser.CloseAsync();
        }
    }
}