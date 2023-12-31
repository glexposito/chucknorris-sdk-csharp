using ChuckNorris.Sdk.Infrastructure.Services;
using FluentAssertions;

namespace ChuckNorris.Sdk.Tests;

public class ChuckNorrisApiClientTest
{
    private readonly ChuckNorrisApiClient _client = new(new HttpClient { BaseAddress = new Uri("https://api.chucknorris.io/jokes") });

    [Fact]
    public async void GetCategoriesAsync_ShouldReturnCategories()
    {
        var categories = await _client.GetCategoriesAsync();

        categories.Should().NotBeEmpty();
    }
    
    [Fact]
    public async void GetRandomChuckJokeAsync_ShouldReturnChuckJoke()
    {
        var chuckJoke = await _client.GetRandomChuckJokeAsync();
        
        chuckJoke.CreatedAt.Should().NotBeNullOrWhiteSpace();
        chuckJoke.IconUrl.Should().NotBeNullOrWhiteSpace();
        chuckJoke.Id.Should().NotBeNullOrWhiteSpace();
        chuckJoke.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        chuckJoke.Url.Should().NotBeNullOrWhiteSpace();
        chuckJoke.Value.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async void GetChuckJokeByCategoryAsync_WithValidCategory_ShouldReturnChuckJoke()
    {
        var chuckJoke = await _client.GetChuckJokeByCategoryAsync("dev");

        chuckJoke.Categories.Should().NotBeEmpty();
        chuckJoke.CreatedAt.Should().NotBeNullOrWhiteSpace();
        chuckJoke.IconUrl.Should().NotBeNullOrWhiteSpace();
        chuckJoke.Id.Should().NotBeNullOrWhiteSpace();
        chuckJoke.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        chuckJoke.Url.Should().NotBeNullOrWhiteSpace();
        chuckJoke.Value.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async void GetChuckJokeByCategoryAsync_WithInvalidCategory_ShouldThrowHttpRequestException_404_NotFound()
    {
        Func<Task> act = () =>  _client.GetChuckJokeByCategoryAsync("gu1ll3e");
        
        await act.Should()
            .ThrowAsync<HttpRequestException>()
            .WithMessage("Response status code does not indicate success: 404 (Not Found).");
    }
    
    [Fact]
    public async void SearchChuckJokeByTextAsync_WithExistingText_ShouldReturnChuckJokes()
    {
        var response = await _client.SearchChuckJokeByTextAsync("dev");

        response.Total.Should().BePositive();

        foreach (var chuckJoke in response.Result)
        {
            chuckJoke.CreatedAt.Should().NotBeNullOrWhiteSpace();
            chuckJoke.IconUrl.Should().NotBeNullOrWhiteSpace();
            chuckJoke.Id.Should().NotBeNullOrWhiteSpace();
            chuckJoke.UpdatedAt.Should().NotBeNullOrWhiteSpace();
            chuckJoke.Url.Should().NotBeNullOrWhiteSpace();
            chuckJoke.Value.Should().NotBeNullOrWhiteSpace();
        }
    }
    
    [Fact]
    public async void SearchChuckJokeByTextAsync_WithNonExistingText_ShouldNotReturnChuckJokes()
    {
        var response = await _client.SearchChuckJokeByTextAsync("gu1ll3e");

        response.Total.Should().Be(0);

        foreach (var chuckJoke in response.Result)
        {
            chuckJoke.CreatedAt.Should().NotBeNullOrWhiteSpace();
            chuckJoke.IconUrl.Should().NotBeNullOrWhiteSpace();
            chuckJoke.Id.Should().NotBeNullOrWhiteSpace();
            chuckJoke.UpdatedAt.Should().NotBeNullOrWhiteSpace();
            chuckJoke.Url.Should().NotBeNullOrWhiteSpace();
            chuckJoke.Value.Should().NotBeNullOrWhiteSpace();
        }
    }
}
