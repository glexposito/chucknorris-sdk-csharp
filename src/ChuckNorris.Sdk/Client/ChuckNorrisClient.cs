using ChuckNorris.Sdk.Client.Models;
using ChuckNorris.Sdk.Infrastructure.Services;
using ChuckNorris.Sdk.Infrastructure.Services.Models;

namespace ChuckNorris.Sdk.Client;

public class ChuckNorrisClient : IChuckNorrisClient
{
    private readonly IChuckNorrisApiClient _apiClient;

    public ChuckNorrisClient(IChuckNorrisApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public Task<ChuckNorrisApiResponse<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ChuckNorrisApiResponse<ChuckJoke>> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ChuckNorrisApiResponse<ChuckJoke>> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ChuckNorrisApiResponse<TextSearchResult>> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}