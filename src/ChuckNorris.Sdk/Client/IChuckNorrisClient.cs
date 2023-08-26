using ChuckNorris.Sdk.Client.Models;

namespace ChuckNorris.Sdk.Client;

public interface IChuckNorrisClient
{
    Task<CategoriesResponse> GetCategoriesAsync(CancellationToken cancellationToken = default);
    
    Task<ChuckJokeResponse> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default);
    
    Task<ChuckJokeResponse> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default);
    
    Task<SearchChuckJokeResponse> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default);
}