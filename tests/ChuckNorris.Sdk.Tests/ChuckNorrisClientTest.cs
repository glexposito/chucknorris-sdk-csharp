using ChuckNorris.Sdk.Client;
using ChuckNorris.Sdk.Infrastructure.Services;
using FluentAssertions;

namespace ChuckNorris.Sdk.Tests;

public class ChuckNorrisClientTest
{
    private readonly ChuckNorrisClient _client = new(new ChuckNorrisApiClient(new HttpClient() { BaseAddress = new Uri("https://api.chucknorris.io/jokes") }));

    [Fact]
    public async void GetCategoriesAsync_ShouldReturnResponse_WithCategories()
    {
        var response = await _client.GetCategoriesAsync();
        
        response.Success.Should().BeTrue();
        response.Error.Should().BeNullOrWhiteSpace();
        response.Categories.Should().NotBeEmpty();
    }
    
    [Fact]
    public async void GetRandomChuckJokeAsync_ShouldReturnResponse_WithChuckJoke()
    {
        var response = await _client.GetRandomChuckJokeAsync();

        response.Success.Should().BeTrue();
        response.Error.Should().BeNullOrWhiteSpace();
        response.ChuckJoke!.Categories.Should().BeEmpty();
        response.ChuckJoke!.CreatedAt.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.IconUrl.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Id.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Url.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Value.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async void GetChuckJokeByCategoryAsync_WithValidCategory_ShouldReturnChuckJoke()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("dev");
    
        response.Success.Should().BeTrue();
        response.Error.Should().BeNullOrWhiteSpace();
        response.ChuckJoke!.Categories.Should().NotBeEmpty();
        response.ChuckJoke!.CreatedAt.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.IconUrl.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Id.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Url.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Value.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async void GetChuckJokeByCategoryAsync_WithInvalidCategory_ShouldThrowHttpRequestException_404_NotFound()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("gu1ll3e");
    
        response.Success.Should().BeFalse();
        response.Error.Should().Contain("404");
        response.ChuckJoke.Should().BeNull();
    }
    
    [Fact]
    public async void SearchChuckJokeByTextAsync_WithExistingText_ShouldReturnChuckJokes()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("dev");
    
        response.Success.Should().BeTrue();
        response.Error.Should().BeNull();
        
        response.ChuckJoke!.Categories.Should().NotBeEmpty();
        response.ChuckJoke!.CreatedAt.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.IconUrl.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Id.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Url.Should().NotBeNullOrWhiteSpace();
        response.ChuckJoke!.Value.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async void SearchChuckJokeByTextAsync_WithNonExistingText_ShouldNotReturnChuckJokes()
    {
        var response = await _client.SearchChuckJokeByTextAsync("gu1ll3e");

        response.TextSearchResult!.Total.Should().Be(0);
    }
}
