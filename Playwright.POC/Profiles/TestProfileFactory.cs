using System;

namespace Playwright.POC.Profiles
{
    public static class TestProfileFactory
    {
        public static ITestProfile GetDefaultProfile()
        {
            return new QAProfile();
        }
        
        public static ITestProfile GetProfile(string profileName)
        {
            return profileName.ToLower() switch
            {
                "qa" => new QAProfile(),
                "staging" => new StagingProfile(),
                _ => throw new Exception("The profile could not be found, valid profiles are: 'qa' and 'staging'")
            };
        }
    }
}