using ChuckNorris.Sdk.Infrastructure.Services.Models;

namespace ChuckNorris.Sdk.Client.Models;

public class ChuckJokeResponse : ChuckNorrisApiResponse
{
    public ChuckJoke? ChuckJoke { get; set; }
}