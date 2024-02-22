### Prerequsities
Add this package reference into the project:
```csharp
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0" />
</ItemGroup>
```

### Console Example for DI (Dependency Injection)
This example create services for dependency Injection. And write console log about each service lifetime to see that :
1. **AddTransient** 	: Always changes
2. **AddScoped** 		: Changes only with lifetime
3. **AddSingleton** 	: Always the same


------------
With the following code block we are creating two lifetime.
```csharp
ExemplifyServiceLifetime(host.Services, "Lifetime 1");
ExemplifyServiceLifetime(host.Services, "Lifetime 2");
```

This method is :

```csharp
static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"1. {lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");

    Console.WriteLine();

    logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"2. {lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");

    Console.WriteLine("".PadLeft(80,'#'));


    Console.WriteLine();
}
```


Output :
### Prerequsities
Add this package reference into the project:
```csharp
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0" />
</ItemGroup>
```

### Console Example for DI (Dependency Injection)
This example create services for dependency Injection. And write console log about each service lifetime to see that :
1. **AddTransient** 	: Always changes
2. **AddScoped** 		: Changes only with lifetime
3. **AddSingleton** 	: Always the same


------------
With the following code block we are creating two lifetime.
```csharp
ExemplifyServiceLifetime(host.Services, "Lifetime 1");
ExemplifyServiceLifetime(host.Services, "Lifetime 2");
```

This method is :

```csharp
static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"1. {lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");

    Console.WriteLine();

    logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"2. {lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");

    Console.WriteLine("".PadLeft(80,'#'));


    Console.WriteLine();
}
```


Output :

Lifetime 1: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()
    IExampleTransientService: bf49a26d-a94b-4c21-86b9-2b73a699c3d8 (Always different)
    IExampleScopedService: ab4a680f-03ae-45e9-a9f9-2a566b44419c (Changes only with lifetime)
    IExampleSingletonService: 9d251473-2951-4179-b934-3d1546b7983c (Always the same)

Lifetime 1: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()
    IExampleTransientService: 5cdd1dbb-5843-481b-8ffd-37dc213a107f (Always different)
    IExampleScopedService: ab4a680f-03ae-45e9-a9f9-2a566b44419c (Changes only with lifetime)
    IExampleSingletonService: 9d251473-2951-4179-b934-3d1546b7983c (Always the same)


Lifetime 2: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()
    IExampleTransientService: aa48d177-9793-45e9-8070-366059610857 (Always different)
    IExampleScopedService: c7d73cf8-9d15-4903-8a8b-b8d4a6005c3a (Changes only with lifetime)
    IExampleSingletonService: 9d251473-2951-4179-b934-3d1546b7983c (Always the same)

Lifetime 2: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()
    IExampleTransientService: 752aee78-00dc-4a29-af0e-afb41547e56c (Always different)
    IExampleScopedService: c7d73cf8-9d15-4903-8a8b-b8d4a6005c3a (Changes only with lifetime)
    IExampleSingletonService: 9d251473-2951-4179-b934-3d1546b7983c (Always the same)


------------

### For detailed information :
Read this article from Microsoft Documentation
[Tutorial: Use dependency injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage)

------------