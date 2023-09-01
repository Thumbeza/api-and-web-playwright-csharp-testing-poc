using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.Web.Testing.Poc.Assembly;
using Playwright.Web.Testing.Poc.Browsers;
using Playwright.Web.Testing.Poc.TestData;
using TestParameters = Playwright.Web.Testing.Poc.TestData.TestParameters;

namespace Playwright.Web.Testing.Poc.Tests
{
    //Login fixture utilising page object model to generate tests
    public class LoginTests
    {
        private IBrowser _browser;
        private IPage _page;
        private PageLoader _pageLoader;
        
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

            _pageLoader = new PageLoader(_page);
        }
        
        [Test]
        public async Task LoginWithCorrectCredentials()
        {
            var isLoginPageVisible = await _pageLoader.SignInPage.IsPageVisibleAsync();

            isLoginPageVisible.Should().BeTrue();

            await _pageLoader.SignInPage.LoginToExporter(Users.StandardUser, TestParameters.Password);

            var isLandingPageVisible = await _pageLoader.LandingPage.IsPageVisibleAsync();

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