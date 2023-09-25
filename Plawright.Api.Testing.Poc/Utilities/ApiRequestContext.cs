using Microsoft.Playwright;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plawright.Api.Testing.Poc.Utilities;

public class ApiRequestContext
{
    private readonly string _baseUrl;
    private readonly Dictionary<string, string> _additionalHeaders;

    public ApiRequestContext(string baseUrl, Dictionary<string, string> additionalHeaders = null)
    {
        _baseUrl = baseUrl;
        _additionalHeaders = additionalHeaders;
    }

    public IAPIRequestContext Request = null;

    public async Task CreateAsync()
    {
        var headers = new Dictionary<string, string>
        {
            { "Accept", "application/json" }
        };

        if (_additionalHeaders != null)
        { 
            foreach (var header in _additionalHeaders) 
            { 
                headers.Add(header.Key, header.Value);
            }
        }

        var playwright = await Playwright.CreateAsync();

        Request = await playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = _baseUrl,
            ExtraHTTPHeaders = headers
        });
    }
}
