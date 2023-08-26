namespace ChuckNorris.Sdk.Client.Models;

public abstract class ChuckNorrisApiResponse
{
    public bool IsSuccessful { get; set; }

    public string? Error { get; set; }
}