using Xunit;

namespace Playwright.POC.Tests
{
    public class SampleFixture : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture fixture;

        public SampleFixture(BaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void Login()
        {
            //await fixture.PageLoader.SignIn.Goto();
            //await fixture.PageLoader.SignIn.LoginToExporter("", "");

            //var signInPage = new SignInPage(await fixture.Browser.NewPageAsync(), fixture.Profile);

            //await signInPage.Goto();
            //await signInPage.LoginToExporter(Users.AdminUser, TestParameters.Password);

            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();

            var page = await browser.NewPageAsync();
            await page.GotoAsync(fixture.Profile.Uri);
        }
    }
}