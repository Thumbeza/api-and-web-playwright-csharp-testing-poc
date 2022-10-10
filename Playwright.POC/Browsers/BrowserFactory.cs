using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.POC.Browsers
{
    public static class BrowserFactory
    {
        public static async Task<IBrowser> LaunchBrowser(bool isHeadless = true)
        {
            return await GetChromeBrowser(isHeadless);
        }
        
        public static async Task<IBrowser> LaunchBrowser(string browserName, bool isHeadless = true)
        {
            return browserName.ToLower() switch
            {
                "chrome" => await GetChromeBrowser(isHeadless),
                "edge" => await GetEdgeBrowser(isHeadless),
                "firefox" => await GetFirefoxBrowser(isHeadless),
                "webkit" => await GetWebkitBrowser(isHeadless),
                _ => throw new Exception("")
            };
        }

        private static async Task<IBrowser> GetChromeBrowser(bool isHeadless)
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var chromium = playwright.Chromium;
            
            return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "chrome", 
                Headless = isHeadless
            });
        }
        
        private static async Task<IBrowser> GetEdgeBrowser(bool isHeadless)
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge",
                Headless = isHeadless
            });
        }
        
        private static async Task<IBrowser> GetFirefoxBrowser(bool isHeadless)
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = isHeadless
            });
        }
        
        private static async Task<IBrowser> GetWebkitBrowser(bool isHeadless)
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            return await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = isHeadless
            });
        }
    }
}