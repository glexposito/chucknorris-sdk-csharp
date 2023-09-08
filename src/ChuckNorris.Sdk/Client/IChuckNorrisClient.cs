using ChuckNorris.Sdk.Client.Models;

namespace ChuckNorris.Sdk.Client;

public interface IChuckNorrisClient
{
    /// <summary>
    /// Retrieves a list of available categories in an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the GetCategoriesAsync service method with the list of categories.
    /// </returns>
    Task<CategoriesResponse> GetCategoriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a random chuck joke in an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the GetRandomChuckJokeAsync service method with the chuck joke.
    /// </returns>
    Task<ChuckJokeResponse> GetRandomChuckJokeAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a random chuck joke from a given category in an asynchronous operation.
    /// </summary>
    /// <param name="category">The category used to retrieve a chuck joke.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the GetChuckJokeByCategoryAsync service method with the chuck joke.
    /// </returns>
    Task<ChuckJokeResponse> GetChuckJokeByCategoryAsync(string category, CancellationToken cancellationToken = default);

    /// <summary>
    /// Free text search in an asynchronous operation.
    /// </summary>
    /// <param name="text">The text used to search for chuck jokes.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>
    /// The response from the SearchChuckJokeByTextAsync service method with the found chuck jokes.
    /// </returns>
    Task<SearchChuckJokeResponse> SearchChuckJokeByTextAsync(string text, CancellationToken cancellationToken = default);
}