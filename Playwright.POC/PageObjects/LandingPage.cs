using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.POC.PageObjects
{
    public class LandingPage : Pages
    {
        private readonly ILocator _productsLabel;

        public LandingPage(IPage page) : base(page)
        {
            _productsLabel = page.Locator("[class='title']");
        }

        public async Task<bool> IsPageVisibleAsync()
        {
            return await IsLocatorVisibleAsync(_productsLabel);
        }
    }
}