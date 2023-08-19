using ChuckNorris.Sdk.Infrastructure.Services.Models;

namespace ChuckNorris.Sdk.Client.Models;

public class SearchChuckJokeResponse : ChuckNorrisApiResponse
{
    public TextSearchResult? TextSearchResult { get; set; }
}