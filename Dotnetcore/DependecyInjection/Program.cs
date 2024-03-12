using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var services = new ServiceCollection();
            services.AddSingleton<CustomService>();
            services.AddTransient<IMessageWriter, MessageWriter>();
            services.AddLogging(configure => configure.AddConsole());

            IServiceProvider provider = services.BuildServiceProvider();
            var app = provider.GetService<CustomService>();

            app!.Run();
        }
        finally
        {
            Console.ReadKey();
        }
    }

}

public class CustomService
{
    private readonly ILogger<CustomService> _logger;
    private readonly IMessageWriter _messageWriter;

    public CustomService(ILogger<CustomService> logger, IMessageWriter messageWriter)
    {
        _logger = logger;
        _messageWriter = messageWriter;

        logger.LogInformation("CustomService constructor.");
    }
    public bool Run()
    {
        _messageWriter.Write("Hello !");

        _logger.LogInformation("I'm logger.");
        _logger.LogInformation("and I'm running..");
        return true;
    }
}

public class MessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"\n## Message writer says: {message}\n");
    }
}

public interface IMessageWriter
{
    void Write(string message);
}
