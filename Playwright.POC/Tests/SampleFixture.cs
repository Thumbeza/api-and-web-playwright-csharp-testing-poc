using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.POC.Browsers;
using Playwright.POC.PageObjects;
using Playwright.POC.TestData;
using TestParameters = Playwright.POC.TestData.TestParameters;

namespace Playwright.POC.Tests
{
    public class SampleFixture
    {
        private IBrowser _browser;
        private IPage _page;
        
        [SetUp]
        public async Task Setup()
        {
            var browserFactory = new BrowserFactory(false);

            _browser = await browserFactory.LaunchBrowser("edge");
            
            _page = await _browser.NewPageAsync(new BrowserNewPageOptions
            {
                BaseURL = Url.SwagLabs,
                ColorScheme = ColorScheme.Dark
            });
        }

        [Test]
        public async Task LoginWithCorrectCredentials()
        {
            var signInPage = new SignInPage(_page);
            var isLoginPageVisible = await signInPage.IsPageVisibleAsync();

            isLoginPageVisible.Should().BeTrue();

            await signInPage.LoginToExporter(Users.StandardUser, TestParameters.Password);

            var landingPage = new LandingPage(_page);
            var isLandingPageVisible = await landingPage.IsPageVisibleAsync();

            isLandingPageVisible.Should().BeTrue();
        }

        [TearDown]
        public async Task Teardown()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
        }
    }
}