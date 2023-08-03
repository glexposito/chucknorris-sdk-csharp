namespace ChuckNorris.Sdk.Infrastructure.Services;

public interface IChuckNorrisApiClient
{
    Task<IEnumerable<string>> GetCategories();
    
    Task<ChuckJoke> GetRandomChuckJoke();
    
    Task<ChuckJoke> GetChuckJokeByCategory(string category);
    
    Task<IEnumerable<ChuckJoke>> SearchChuckJokeByText(string text);
}