using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DependencyInjection_2.Services;
using System.Diagnostics;
internal class Program
{
    private static async Task Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddTransient<IExampleTransientService, ExampleTransientService>();
        builder.Services.AddScoped<IExampleScopedService, ExampleScopedService>();
        builder.Services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
        builder.Services.AddTransient<ServiceLifetimeReporter>();

        using IHost host = builder.Build();

        ExemplifyServiceLifetime(host.Services, "Lifetime 1");
        ExemplifyServiceLifetime(host.Services, "Lifetime 2");

        await host.RunAsync();

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

            Console.WriteLine("".PadLeft(100,'-'));


            Console.WriteLine();
        }
    }
}