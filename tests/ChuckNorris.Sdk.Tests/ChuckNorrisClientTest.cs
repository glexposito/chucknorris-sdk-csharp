using ChuckNorris.Sdk.Client;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChuckNorris.Sdk.Tests;

public class ChuckNorrisClientTest
{
    private readonly IChuckNorrisClient _client;
    
    public ChuckNorrisClientTest()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddChuckNorrisSdk();
        using var host = builder.Build();
        using var serviceScope = host.Services.CreateScope();
        var provider = serviceScope.ServiceProvider;
        
        _client = provider.GetRequiredService<IChuckNorrisClient>();
    }
    
    [Fact]
    public async void GetCategoriesAsync_ShouldReturnResponse_WithCategories()
    {
        var response = await _client.GetCategoriesAsync();
        
        response.IsSuccessful.Should().BeTrue();
        response.Error.Should().BeNullOrWhiteSpace();
        response.Categories.Should().NotBeEmpty();
    }
    
    [Fact]
    public async void GetRandomChuckJokeAsync_ShouldReturnResponse_WithChuckJoke()
    {
        var response = await _client.GetRandomChuckJokeAsync();

        response.IsSuccessful.Should().BeTrue();
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
    
        response.IsSuccessful.Should().BeTrue();
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
    
        response.IsSuccessful.Should().BeFalse();
        response.Error.Should().Contain("404");
        response.ChuckJoke.Should().BeNull();
    }
    
    [Fact]
    public async void SearchChuckJokeByTextAsync_WithExistingText_ShouldReturnChuckJokes()
    {
        var response = await _client.GetChuckJokeByCategoryAsync("dev");
    
        response.IsSuccessful.Should().BeTrue();
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