# PasswordHasher.SHA256.ASP.NET.CORE.Identity

This is a package to use the custom password hasher with `SHA256` algorithm and `base64` encoding for IdentityServer4 or any `ASP.NET Core` project using `Microsoft.AspNetCore.Identity` dependency.

> Generated hashed value structure

```
[SHA256 hashed + BASE64 encoded password]$[Guid salt]

# e.g. W9G4GjOAE47HKq2ktI/RXhYBgqv5vIsWYF5GfR5jy7o=$e6126315-2425-4aa2-bfba-0986e49590e8
```

The salt value after `$`  which was generated using `System.Guid` will be used to verify the password which is input by user.

## Installation

### dotnet CLI

```shell
$ dotnet add package PasswordHasher.SHA256.ASP.NET.CORE.Identity
```

### NuGet
https://www.nuget.org/packages/PasswordHasher.SHA256.ASP.NET.CORE.Identity

## Usage

```csharp
// Startup.cs

using SHA256Hasher;

public void ConfigureServices(IServiceCollection services)
{
    var connectionString = Configuration.GetConnectionString("DefaultConnection");
    var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

    // ADD CustomPasswordHasher
    services.AddTransient<IPasswordHasher<IdentityUser>, CustomPasswordHasher>();
    
    // omit the rest of codes
```

## Demo

```shell
$ cd console
$ dotnet run

# The provided password "StrongPassw0rd!"

HashedValue > W9G4GjOAE47HKq2ktI/RXhYBgqv5vIsWYF5GfR5jy7o=$e6126315-2425-4aa2-bfba-0986e49590e8
Verify > Success
```
