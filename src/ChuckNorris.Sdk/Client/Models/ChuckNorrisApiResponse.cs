namespace ChuckNorris.Sdk.Client.Models;

public record ChuckNorrisApiResponse<T>(bool Success, string? Error, T? Data);