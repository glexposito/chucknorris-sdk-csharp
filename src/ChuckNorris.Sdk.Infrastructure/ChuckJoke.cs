using System.Text.Json.Serialization;

namespace ChuckNorris.Sdk.Infrastructure;

// ReSharper disable once ClassNeverInstantiated.Global
public record ChuckJoke {
    [JsonPropertyName("categories")]
    public required IEnumerable<string> Categories { get; init; }
    
    [JsonPropertyName("created_at")]
    public required string CreateadAt { get; init; }
    
    [JsonPropertyName("icon_url")]
    public required string IconUrl { get; init; }
    
    [JsonPropertyName("id")]
    public required string Id { get; init; }
    
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; init; }
    
    [JsonPropertyName("url")]
    public required string  Url { get; init; }
    
    [JsonPropertyName("value")]
    public required string Value { get; init; }
}