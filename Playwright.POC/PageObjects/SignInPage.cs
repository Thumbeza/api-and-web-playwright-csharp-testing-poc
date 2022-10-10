using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.POC.Profiles;

namespace Playwright.POC.PageObjects
{
    public class SignInPage
    {
        private readonly IPage page;
        private readonly ITestProfile profile;
        
        private readonly ILocator usernameInput;
        private readonly ILocator passwordInput;
        private readonly ILocator signInButton;

        public SignInPage(IPage page, ITestProfile profile)
        {
            this.page = page;
            this.profile = profile;
            
            usernameInput = page.Locator("[name='username']");
            passwordInput = page.Locator("[name='password']");
            signInButton = page.Locator("[name='login']");
        }
        
        public async Task Goto()
        {
            await page.GotoAsync(profile.Uri);
        }

        public async Task LoginToExporter(string username, string password)
        {
            await usernameInput.FillAsync(username);
            await passwordInput.FillAsync(password);
            await signInButton.ClickAsync();
        }
    }
}