using ChuckNorris.Sdk.Client.Models;

namespace ChuckNorris.Sdk.Client;

public interface IChuckNorrisClient
{
    /// <summary>
    /// Retrieves a list of available categories in an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    Task<CategoriesResponse> GetCategoriesAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a random chuck joke in an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    Task<ChuckJokeResponse> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a random chuck joke from a given category in an asynchronous operation.
    /// </summary>
    /// <param name="category">The category used to retrieve a chuck joke.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    Task<ChuckJokeResponse> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Free text search in an asynchronous operation.
    /// </summary>
    /// <param name="text">The text used to search for chuck jokes.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    Task<SearchChuckJokeResponse> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default);
}