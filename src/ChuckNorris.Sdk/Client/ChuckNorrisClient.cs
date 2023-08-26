using ChuckNorris.Sdk.Client.Models;
using ChuckNorris.Sdk.Infrastructure.Services;

namespace ChuckNorris.Sdk.Client;

public class ChuckNorrisClient : IChuckNorrisClient
{
    private const string UnknownError = "An unknown error occurred. Please try again.";
    private readonly IChuckNorrisApiClient _apiClient;

    public ChuckNorrisClient(IChuckNorrisApiClient apiClient)
    {
        _apiClient = apiClient;
    }
    
    public async Task<CategoriesResponse> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var response = new CategoriesResponse();
        
        try
        {
            var categories = await _apiClient.GetCategoriesAsync(cancellationToken);
            
            response.IsSuccessful = true;
            response.Categories = categories;
        }
        catch (HttpRequestException e)
        {
            response.Error = e.Message;
        }
        catch (Exception)
        {
            response.Error = UnknownError;
        }

        return response;
    }

    public async Task<ChuckJokeResponse> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default)
    {
        var response = new ChuckJokeResponse();
        
        try
        {
            var chuckJoke = await _apiClient.GetRandomChuckJokeAsync(cancellationToken);
        
            response.IsSuccessful = true;
            response.ChuckJoke = chuckJoke;
        }
        catch (HttpRequestException e)
        {
            response.Error = e.Message;
        }
        catch (Exception)
        {
            response.Error = UnknownError;
        }
        
        return response;
    }

    public async Task<ChuckJokeResponse> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        var response = new ChuckJokeResponse();
        
        try
        {
            var chuckJoke = await _apiClient.GetChuckJokeByCategoryAsync(category, cancellationToken);
        
            response.IsSuccessful = true;
            response.ChuckJoke = chuckJoke;
        }
        catch (HttpRequestException e)
        {
            response.Error = e.Message;
        }
        catch (Exception)
        {
            response.Error = UnknownError;
        }
        
        return response;
    }

    public async Task<SearchChuckJokeResponse> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default)
    {
        var response = new SearchChuckJokeResponse();
        
        try
        {
            var searchResult = await _apiClient.SearchChuckJokeByTextAsync(text, cancellationToken);
        
            response.IsSuccessful = true;
            response.TextSearchResult = searchResult;
        }
        catch (HttpRequestException e)
        {
            response.Error = e.Message;
        }
        catch (Exception)
        {
            response.Error = UnknownError;
        }
        
        return response;
    }
}