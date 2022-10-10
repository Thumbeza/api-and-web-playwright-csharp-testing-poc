using System;
using System.Linq;

namespace Playwright.POC.Utils
{
    public static class EnvironmentVariables
    {
        public static string GetEnvironmentVariable(string environmentVariable)
        {
            return (from EnvironmentVariableTarget target in Enum.GetValues(typeof(EnvironmentVariableTarget)) 
                    select Environment.GetEnvironmentVariable(environmentVariable, target))
                .FirstOrDefault(potentialEnvironmentVariable => !string.IsNullOrEmpty(potentialEnvironmentVariable));
        }
    }
}