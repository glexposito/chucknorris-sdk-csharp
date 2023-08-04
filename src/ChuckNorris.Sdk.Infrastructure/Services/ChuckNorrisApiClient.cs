using RestSharp;

namespace ChuckNorris.Sdk.Infrastructure.Services;

public class ChuckNorrisApiClient : IChuckNorrisApiClient, IDisposable 
{
    private readonly RestClient _client;

    public ChuckNorrisApiClient() {
        var options = new RestClientOptions("https://api.chucknorris.io/jokes");
        _client = new RestClient(options);
    }
    
    public async Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return (await _client.GetJsonAsync<IEnumerable<string>>("categories", cancellationToken))!;
    }
    
    public async Task<ChuckJoke> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default)
    {
        return (await _client.GetJsonAsync<ChuckJoke>("random", cancellationToken))!;
    }

    public async Task<ChuckJoke> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("random");
        request.AddQueryParameter("category", category);
        
        return (await _client.GetAsync<ChuckJoke>(request, cancellationToken))!;
    }

    public async Task<TextSearchResponse> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("search");
        request.AddQueryParameter("query", text);
        
        return (await _client.GetAsync<TextSearchResponse>(request, cancellationToken))!;
    }
    
    public void Dispose() {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}