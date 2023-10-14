# ChuckNorris SDK

![Build status](https://github.com/glexposito/chucknorris-sdk-csharp/actions/workflows/ci.yml/badge.svg?branch=master)

![](https://raw.githubusercontent.com/glexposito/chucknorris-sdk-csharp/master/chuck-icon.png)

A C# SDK created for the https://api.chucknorris.io/ API (as a very simple example about "creating a SDK" for a friend who is taking his first steps as a developer).

## Supported Platforms

* .NET 7 or greater

## Getting Started

ChuckNorris C# SDK for .NET is [available on NuGet](https://www.nuget.org/packages/ChuckNorris.Sdk) and it can be installed through the following options:

Package Manager:

	>Install-Package ChuckNorris.Sdk 

.NET CLI:

	>dotnet add package ChuckNorris.Sdk 

Add ChuckNorris C# SDK to the container
```c#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddChuckNorrisSdk();
```

## Usage examples
Get a random chuck joke.

```c#
using System.Net;
using ChuckNorris.Sdk.Client;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ChuckNorrisController : ControllerBase
{
    private readonly IChuckNorrisClient _client;

    public ChuckNorrisController(IChuckNorrisClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> GetRandomJoke()
    {
        var response = await _client.GetRandomChuckJokeAsync();
        
        if (response.IsSuccessful)
        {
            return Ok(response.ChuckJoke!.Value);
        }

        var problemDetails = new ProblemDetails
        {
            Status = (int)HttpStatusCode.BadGateway,
            Title = "Downstream call failed",
            Detail = "An error occurred while calling https://api.chucknorris.io API."
        };

        return new ObjectResult(problemDetails);
    }
}
```

Get a list of available categories.

```c#
var response = await _client.GetCategoriesAsync();

var categories = response.Categories;
```

Get a random chuck joke given a category.

```c#
var response = await _client.GetChuckJokeByCategoryAsync("sport");

var joke = response.ChuckJoke!.Value;
```

Get chuck jokes by using full text search.

```c#
var response = await _client.SearchChuckJokeByTextAsync("dev");
        
var total = response.TextSearchResult!.Total;

Console.WriteLine($"{total} chuck jokes found!");

var result = response.TextSearchResult!.Result;

foreach (var joke in result)
{
    Console.WriteLine(joke.Value);
}
```

## Contribute

Coming soon!

## Problems?

If you find an issue, please visit the [issue tracker](https://github.com/glexposito/chucknorris-sdk-csharp/issues) and report the issue.

Please be kind and search to see if the issue is already logged before creating a new one. If you're pressed for time, log it anyways.

When creating an issue, clearly explain

* What you were trying to do.
* What you expected to happen.
* What actually happened.
* Steps to reproduce the problem.

Also include any other information you think is relevant to reproduce the problem.

## Copyright and License

Copyright (c) Guillermo Exposito 2023

Licensed under the [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0.txt)