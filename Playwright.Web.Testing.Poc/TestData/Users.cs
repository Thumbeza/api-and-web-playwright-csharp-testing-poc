using Playwright.Web.Testing.Poc.Utils;

namespace Playwright.Web.Testing.Poc.TestData
{
    public static class Users
    {
        public static string StandardUser => EnvironmentVariables.GetEnvironmentVariable("SAUCE_DEMO_USER");
    }
}