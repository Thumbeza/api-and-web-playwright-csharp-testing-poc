using Newtonsoft.Json;

namespace Plawright.Api.Testing.Poc.Utilities;

public static class JsonConverter
{
    public static T Deserialize<T>(string jsonText) where T : class
    {
        return JsonConvert.DeserializeObject<T>(jsonText);
    }
}
