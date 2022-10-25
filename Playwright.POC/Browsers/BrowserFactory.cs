using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.POC.Browsers
{
    public class BrowserFactory : IBrowserFactory
    {
        private readonly bool _isHeadless;

        public BrowserFactory(bool isHeadless)
        {
            _isHeadless = isHeadless;
        }

        public async Task<IBrowser> LaunchBrowser()
        {
            return await GetChromeBrowser();
        }
        
        public async Task<IBrowser> LaunchBrowser(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => await GetChromeBrowser(),
                "edge" => await GetEdgeBrowser(),
                "firefox" => await GetFirefoxBrowser(),
                "webkit" => await GetWebkitBrowser(),
                _ => throw new Exception("Invalid browser passed, accepted browsers are: ")
            };
        }

        private async Task<IBrowser> GetChromeBrowser()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "chrome", 
                Headless = _isHeadless
            });
        }
        
        private async Task<IBrowser> GetEdgeBrowser()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge",
                Headless = _isHeadless
            });
        }
        
        private async Task<IBrowser> GetFirefoxBrowser()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _isHeadless
            });
        }
        
        private async Task<IBrowser> GetWebkitBrowser()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _isHeadless
            });
        }
    }
}