using System.Text.Json.Serialization;

namespace Plawright.Api.Testing.Poc.Models;

public class Joke
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("setup")]
    public string Setup { get; set; }
    [JsonPropertyName("punchline")]
    public string Punchline { get; set; }
}
