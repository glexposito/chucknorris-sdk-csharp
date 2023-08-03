using System.Text.Json.Serialization;

namespace ChuckNorris.Sdk.Infrastructure;

public record ChuckJoke {
    [JsonPropertyName("categories")]
    public IEnumerable<string> Categories { get; init; }
    
    [JsonPropertyName("created_at")]
    public string CreateadAt { get; init; }
    
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; init; }
    
    [JsonPropertyName("id")]
    public string Id { get; init; }
    
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }
    
    [JsonPropertyName("url")]
    public string Url { get; init; }
    
    [JsonPropertyName("value")]
    public string Value { get; init; }
}