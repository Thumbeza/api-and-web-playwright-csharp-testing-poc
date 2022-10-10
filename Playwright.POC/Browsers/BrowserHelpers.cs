using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.POC.Browsers
{
    public class BrowserHelpers
    {
        private readonly IPage _page;

        public BrowserHelpers(IPage page)
        {
            _page = page;
        }

        public async Task<string> TakeScreenshot()
        {
            var bytes = await _page.ScreenshotAsync();

            return Convert.ToBase64String(bytes);
        }
        
        public async Task TakeScreenshot(string filePath)
        {
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = filePath,
                FullPage = true,
            });
        }
    }
}