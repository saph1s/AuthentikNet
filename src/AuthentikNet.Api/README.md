# AuthentikNet.Api

A .NET client for the Authentik API.
Package versions follow the target authentik version.

## Installation

Install from your configured NuGet source:

```sh
dotnet add package AuthentikNet.Api --version 2026.8.6
```

## Quick start

```csharp
using AuthentikNet.Api.Client;

using var httpClient = new HttpClient();
var client = new AuthentikClient(httpClient, new AuthentikClientOptions
{
    BaseUrl = "https://authentik.example.com/api/v3",
    Token = Environment.GetEnvironmentVariable("AUTHENTIK_TOKEN")
        ?? throw new InvalidOperationException("Set AUTHENTIK_TOKEN.")
});

var version = await client.Admin.AdminVersionRetrieve();
Console.WriteLine(version.VersionCurrent);
```

Use an API token with the required permissions. `BaseUrl` must include `/api/v3` without a trailing slash. Reuse the
client and its `HttpClient` for subsequent calls.

## Supported APIs

| Client property | Operations                                                                                                                                                  |
|-----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `Admin`         | List apps and models; read and update settings; read system information, version and version history.                                                       |
| `Core`          | List, create, retrieve and partially update users; list and retrieve groups; list, create, retrieve, update, partially update and delete object attributes. |
| `Ssf`           | List Shared Signals Framework streams.                                                                                                                      |
| `Tasks`         | List connected workers.                                                                                                                                     |

## Build and test

Run from the repository root:

```sh
dotnet build AuthentikNet.sln --configuration Release
dotnet test AuthentikNet.sln --configuration Release
dotnet pack src/AuthentikNet.Api/AuthentikNet.Api.csproj --configuration Release
```

Packages are written to `src/AuthentikNet.Api/bin/Release`, which can also be used as a local NuGet source.

## License

Apache-2.0. See `LICENSE` and `NOTICE` in the package.