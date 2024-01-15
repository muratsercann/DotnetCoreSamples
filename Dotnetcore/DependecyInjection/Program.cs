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

            services.AddTransient<Application_MS>();
            services.AddTransient<IMessageWriter, MessageWriter>();
            // services.AddLogging(configure => configure.AddConsole());
            services.AddLogging(configure => configure.AddEventLog());

            IServiceProvider provider = services.BuildServiceProvider();
            var application = provider.GetService<Application_MS>();

            application.Run();
        }
        finally
        {
            Console.WriteLine("\r\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    public class Application_MS
    {
        IMessageWriter messageWriter;
        private readonly ILogger<Application_MS> logger;
        public Application_MS(ILogger<Application_MS> _logger, IMessageWriter _messageWriter)
        {
            messageWriter = _messageWriter;
            logger = _logger;

            Console.WriteLine("public Application(IMessageWriter _messageWriter) {");
        }
        public bool Run()
        {
            messageWriter.Write("message writer in the Run method of the Application class");
            logger.LogInformation("Hello. I'm logger ");
            Console.WriteLine("I'm running yo!");
            return true;
        }
    }
}


public class MessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }
}

public interface IMessageWriter
{
    void Write(string message);
}
