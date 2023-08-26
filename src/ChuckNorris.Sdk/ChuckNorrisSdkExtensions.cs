using ChuckNorris.Sdk.Client;
using ChuckNorris.Sdk.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChuckNorris.Sdk;

public static class ChuckNorrisSdkExtensions
{
    public static void AddChuckNorrisSdk(this IServiceCollection services)
    {
        services.AddHttpClient<IChuckNorrisApiClient, ChuckNorrisApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.chucknorris.io/jokes");
        });
        
        services.AddSingleton<IChuckNorrisClient, ChuckNorrisClient>();
    }
}