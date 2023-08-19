namespace ChuckNorris.Sdk.Client.Models;

public abstract class ChuckNorrisApiResponse
{
    public bool Success { get; set; }

    public string? Error { get; set; }
}