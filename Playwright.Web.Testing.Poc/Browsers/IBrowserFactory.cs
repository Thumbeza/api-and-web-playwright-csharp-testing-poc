using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.Web.Testing.Poc.Browsers
{
    public interface IBrowserFactory
    {
        Task<IBrowser> LaunchBrowser();
        Task<IBrowser> LaunchBrowser(string browserName);
    }
}