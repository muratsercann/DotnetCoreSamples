using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_2.Services
{
    internal sealed class ExampleTransientService : IExampleTransientService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
