using ChuckNorris.Sdk.Client.Models;
using ChuckNorris.Sdk.Infrastructure.Services;
using ChuckNorris.Sdk.Infrastructure.Services.Models;

namespace ChuckNorris.Sdk.Client;

public class ChuckNorrisClient : IChuckNorrisClient
{
    private const string UnknownError = "An unknown error occurred. Please try again.";
    private readonly IChuckNorrisApiClient _apiClient;

    public ChuckNorrisClient(IChuckNorrisApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public async Task<ChuckNorrisApiResponse<IEnumerable<string>>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var categories = await _apiClient.GetCategoriesAsync(cancellationToken);

            return new ChuckNorrisApiResponse<IEnumerable<string>>(true, null, categories);
        }
        catch (HttpRequestException e)
        {
            return new ChuckNorrisApiResponse<IEnumerable<string>>(false, e.Message, null);
        }
        catch (Exception)
        {
            return new ChuckNorrisApiResponse<IEnumerable<string>>(false, UnknownError , null);
        }
    }

    public async Task<ChuckNorrisApiResponse<ChuckJoke>> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var chuckJoke = await _apiClient.GetRandomChuckJokeAsync(cancellationToken);
        
            return new ChuckNorrisApiResponse<ChuckJoke>(true, null, chuckJoke);
        }
        catch (HttpRequestException e)
        {
            return new ChuckNorrisApiResponse<ChuckJoke>(false, e.Message, null);
        }
        catch (Exception)
        {
            return new ChuckNorrisApiResponse<ChuckJoke>(false, UnknownError, null);
        }
    }

    public async Task<ChuckNorrisApiResponse<ChuckJoke>> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        try
        {
            var chuckJoke = await _apiClient.GetChuckJokeByCategoryAsync(category, cancellationToken);
        
            return new ChuckNorrisApiResponse<ChuckJoke>(true, null, chuckJoke);
        }
        catch (HttpRequestException e)
        {
            return new ChuckNorrisApiResponse<ChuckJoke>(false, e.Message, null);
        }
        catch (Exception)
        {
            return new ChuckNorrisApiResponse<ChuckJoke>(false, UnknownError, null);
        }
    }

    public async Task<ChuckNorrisApiResponse<TextSearchResult>> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default)
    {
        try
        {
            var searchResult = await _apiClient.SearchChuckJokeByTextAsync(text, cancellationToken);
        
            return new ChuckNorrisApiResponse<TextSearchResult>(true, null, searchResult);
        }
        catch (HttpRequestException e)
        {
            return new ChuckNorrisApiResponse<TextSearchResult>(false, e.Message, null);
        }
        catch (Exception)
        {
            return new ChuckNorrisApiResponse<TextSearchResult>(false, UnknownError, null);
        }
    }
}