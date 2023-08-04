namespace ChuckNorris.Sdk.Infrastructure.Services;

public interface IChuckNorrisApiClient
{
    Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    
    Task<ChuckJoke> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default);
    
    Task<ChuckJoke> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default);
    
    Task<TextSearchResponse> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default);
}