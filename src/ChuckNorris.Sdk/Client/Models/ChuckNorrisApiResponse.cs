namespace ChuckNorris.Sdk.Client.Models;

public class ChuckNorrisApiResponse<T>
{
    public int? StatusCode { get; set; }
    
    public string? Error { get; set; }
    
    public T? Data { get; set; }
}