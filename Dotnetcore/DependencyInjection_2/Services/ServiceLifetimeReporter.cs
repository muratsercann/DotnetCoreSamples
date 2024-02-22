using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_2.Services
{
    internal sealed class ServiceLifetimeReporter(
    IExampleTransientService transientService,
    IExampleScopedService scopedService,
    IExampleSingletonService singletonService)
    {
        public void ReportServiceLifetimeDetails(string lifetimeDetails)
        {
            Console.WriteLine(lifetimeDetails);

            LogService(transientService, "Always different");
            LogService(scopedService, "Changes only with lifetime");
            LogService(singletonService, "Always the same");
        }

        private static void LogService<T>(T service, string message)
            where T : IReportServiceLifetime =>
            Console.WriteLine(
                $"    {typeof(T).Name}: {service.Id} ({message})");
    }
}
