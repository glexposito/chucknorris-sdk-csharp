namespace ChuckNorris.Sdk.Infrastructure.Services;

public class ChuckNorrisApiClient : IChuckNorrisApiClient
{
    public Task<IEnumerable<string>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Task<ChuckJoke> GetRandomChuckJoke()
    {
        throw new NotImplementedException();
    }

    public Task<ChuckJoke> GetChuckJokeByCategory(string category)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ChuckJoke>> SearchChuckJokeByText(string text)
    {
        throw new NotImplementedException();
    }
}