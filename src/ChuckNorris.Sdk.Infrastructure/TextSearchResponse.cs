using System.Text.Json.Serialization;

namespace ChuckNorris.Sdk.Infrastructure;

// ReSharper disable once ClassNeverInstantiated.Global
public record TextSearchResponse {
    
    [JsonPropertyName("total")]
    public int Total { get; init; }
    
    [JsonPropertyName("result")]
    public required IEnumerable<ChuckJoke> Result { get; init; }
}