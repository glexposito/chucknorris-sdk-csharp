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
    
    /// <summary>
    /// Retrieves a list of available categories in an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the GetCategoriesAsync service method with the list of categories.
    /// </returns>
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
    
    /// <summary>
    /// Retrieves a random chuck joke in an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the GetRandomChuckJokeAsync service method with the chuck joke.
    /// </returns>
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

    /// <summary>
    /// Retrieves a random chuck joke from a given category in an asynchronous operation.
    /// </summary>
    /// <param name="category">The category used to retrieve a chuck joke.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the GetChuckJokeByCategoryAsync service method with the chuck joke.
    /// </returns>
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

    /// <summary>
    /// Free text search in an asynchronous operation.
    /// </summary>
    /// <param name="text">The text used to search for chuck jokes.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the SearchChuckJokeByTextAsync service method with the found chuck jokes.
    /// </returns>
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