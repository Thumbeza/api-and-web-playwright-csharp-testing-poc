using Playwright.POC.Utils;

namespace Playwright.POC.TestData
{
    public static class Users
    {
        public static string StandardUser => EnvironmentVariables.GetEnvironmentVariable("SAUCE_DEMO_PASSWORD");
    }
}