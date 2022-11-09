using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.POC.Browsers;

namespace Playwright.POC.PageObjects
{
    public class SignInPage : Pages
    {
        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _signInButton;

        public SignInPage(IPage page) : base(page)
        {
            _usernameInput = page.Locator("[id='user-name']");
            _passwordInput = page.Locator("[id='password']");
            _signInButton = page.Locator("[id='login-button']");
        }

        public async Task<bool> IsPageVisibleAsync()
        {
            return await IsLocatorVisibleAsync(_usernameInput);
        }

        public async Task LoginToExporter(string username, string password)
        {
            await InsertTextAsync(_usernameInput, username);
            await InsertTextAsync(_passwordInput, password);
            await ClickAsync(_signInButton);
        }
    }
}