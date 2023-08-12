using ChuckNorris.Sdk.Client.Models;
using ChuckNorris.Sdk.Infrastructure.Services.Models;

namespace ChuckNorris.Sdk.Client;

public interface IChuckNorrisClient
{
    Task<ChuckNorrisApiResponse<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    
    Task<ChuckNorrisApiResponse<ChuckJoke>> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default);
    
    Task<ChuckNorrisApiResponse<ChuckJoke>> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default);
    
    Task<ChuckNorrisApiResponse<TextSearchResult>> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default);
}