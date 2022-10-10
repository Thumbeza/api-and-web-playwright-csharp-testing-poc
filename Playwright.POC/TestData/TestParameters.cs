using Playwright.POC.Utils;

namespace Playwright.POC.TestData
{
    public static class TestParameters
    {
        //for best practice, I'm using environment variables to get sensitive data
        //however, the password is publicly available on https://www.saucedemo.com/
        public static string Password => EnvironmentVariables.GetEnvironmentVariable("SAUCE_DEMO_PASSWORD");
    }
}