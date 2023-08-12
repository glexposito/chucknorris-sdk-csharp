using System.Text.Json.Serialization;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ChuckNorris.Sdk.Infrastructure.Services.Models;

// ReSharper disable once ClassNeverInstantiated.Global
public record TextSearchResult {
    [JsonPropertyName("total")]
    public int Total { get; init; }
    
    [JsonPropertyName("result")]
    public required IEnumerable<ChuckJoke> Result { get; init; }
}