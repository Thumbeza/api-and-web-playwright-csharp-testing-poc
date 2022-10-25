using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.POC.PageObjects
{
    public class Pages
    {
        private readonly IPage _page;

        protected Pages(IPage page)
        {
            _page = page;
        }

        protected bool Visible;
        
        protected async Task PageReloadAsync()
        {
            await _page.ReloadAsync();
        }
        
        protected async Task<bool> IsLocatorVisibleAsync(ILocator locator)
        {
            return await locator.IsVisibleAsync();
        }

        protected async Task ClickAsync(ILocator locator)
        {
            await locator.ClickAsync();
        }

        protected async Task InsertTextAsync(ILocator locator, string inputText)
        {
            await locator.FillAsync(inputText);
        }
    }
}