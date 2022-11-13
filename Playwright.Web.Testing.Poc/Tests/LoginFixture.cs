using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.Web.Testing.Poc.Browsers;
using Playwright.Web.Testing.Poc.PageObjects;
using Playwright.Web.Testing.Poc.TestData;
using TestParameters = Playwright.Web.Testing.Poc.TestData.TestParameters;

namespace Playwright.Web.Testing.Poc.Tests
{
    //Login fixture utilising page object model to generate tests
    public class LoginFixture
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