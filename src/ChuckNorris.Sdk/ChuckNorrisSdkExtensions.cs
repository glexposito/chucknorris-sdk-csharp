using ChuckNorris.Sdk.Client;
using ChuckNorris.Sdk.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChuckNorris.Sdk;

public static class ChuckNorrisSdkExtensions
{
    public static IServiceCollection AddChuckNorrisSdk(this IServiceCollection services)
    {
        services.AddTransient<IChuckNorrisClient, ChuckNorrisClient>()
            .AddTransient<IChuckNorrisApiClient, ChuckNorrisApiClient>();
        return services;
    }
}