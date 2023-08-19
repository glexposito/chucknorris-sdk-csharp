namespace ChuckNorris.Sdk.Client.Models;

public class CategoriesResponse : ChuckNorrisApiResponse
{
    public IEnumerable<string>? Categories { get; set; }
}