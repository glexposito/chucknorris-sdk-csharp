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
        response.Data.Should().NotBeEmpty();
    }
    
    [Fact]
    public async void GetRandomChuckJokeAsync_ShouldReturnResponse_WithChuckJoke()
    {
        var response = await _client.GetRandomChuckJokeAsync();

        response.Success.Should().BeTrue();
        response.Error.Should().BeNullOrWhiteSpace();
        response.Data!.Categories.Should().BeEmpty();
        response.Data!.CreatedAt.Should().NotBeNullOrWhiteSpace();
        response.Data!.IconUrl.Should().NotBeNullOrWhiteSpace();
        response.Data!.Id.Should().NotBeNullOrWhiteSpace();
        response.Data!.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        response.Data!.Url.Should().NotBeNullOrWhiteSpace();
        response.Data!.Value.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async void GetChuckJokeByCategoryAsync_WithValidCategory_ShouldReturnChuckJoke()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("dev");
    
        response.Success.Should().BeTrue();
        response.Error.Should().BeNullOrWhiteSpace();
        response.Data!.Categories.Should().NotBeEmpty();
        response.Data!.CreatedAt.Should().NotBeNullOrWhiteSpace();
        response.Data!.IconUrl.Should().NotBeNullOrWhiteSpace();
        response.Data!.Id.Should().NotBeNullOrWhiteSpace();
        response.Data!.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        response.Data!.Url.Should().NotBeNullOrWhiteSpace();
        response.Data!.Value.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async void GetChuckJokeByCategoryAsync_WithInvalidCategory_ShouldThrowHttpRequestException_404_NotFound()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("gu1ll3e");
    
        response.Success.Should().BeFalse();
        response.Error.Should().Contain("404");
        response.Data.Should().BeNull();
    }
    
    [Fact]
    public async void SearchChuckJokeByTextAsync_WithExistingText_ShouldReturnChuckJokes()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("dev");
    
        response.Success.Should().BeTrue();
        response.Error.Should().BeNull();
        
        response.Data!.Categories.Should().NotBeEmpty();
        response.Data!.CreatedAt.Should().NotBeNullOrWhiteSpace();
        response.Data!.IconUrl.Should().NotBeNullOrWhiteSpace();
        response.Data!.Id.Should().NotBeNullOrWhiteSpace();
        response.Data!.UpdatedAt.Should().NotBeNullOrWhiteSpace();
        response.Data!.Url.Should().NotBeNullOrWhiteSpace();
        response.Data!.Value.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async void SearchChuckJokeByTextAsync_WithNonExistingText_ShouldNotReturnChuckJokes()
    {
        var response = await _client.SearchChuckJokeByTextAsync("gu1ll3e");

        response.Data!.Total.Should().Be(0);

        foreach (var chuckJoke in response.Data!.Result)
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
