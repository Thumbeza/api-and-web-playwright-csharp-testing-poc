using FluentAssertions;
using Playwright.POC.Browsers;
using Playwright.POC.PageObjects;
using Xunit;

namespace Playwright.POC.Tests
{
    public class SampleFixture
    {
        [Fact]
        public async void LoginWithCorrectCredentials()
        {
            var browserFactory = new BrowserFactory(false);

            var browser = await browserFactory.LaunchBrowser("edge");
            var page = await browser.NewPageAsync();

            var signInPage = new SignInPage(page);

            await signInPage.LaunchUrl();
            var isPageVisible = await signInPage.IsPageVisible();

            isPageVisible.Should().BeTrue();
        }
    }
}