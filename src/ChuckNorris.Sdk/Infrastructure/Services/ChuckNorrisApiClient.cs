using System.Net.Http.Json;
using ChuckNorris.Sdk.Infrastructure.Services.Models;

namespace ChuckNorris.Sdk.Infrastructure.Services;

public sealed class ChuckNorrisApiClient : IChuckNorrisApiClient
{
    private readonly HttpClient _client;

    public ChuckNorrisApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync<IEnumerable<string>>(_client.BaseAddress + "/categories",cancellationToken))!;
    }

    public async Task<ChuckJoke> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync<ChuckJoke>(_client.BaseAddress + "/random", cancellationToken))!;
    }

    public async Task<ChuckJoke> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync<ChuckJoke>(_client.BaseAddress + $"/random?category={category}", cancellationToken))!;
    }

    public async Task<TextSearchResult> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default)
    {
        return (await _client.GetFromJsonAsync<TextSearchResult>(_client.BaseAddress + $"/search?query={text}", cancellationToken))!;
    }
}