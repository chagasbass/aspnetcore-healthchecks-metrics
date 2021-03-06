using AspnetCore.Healthchecks.Metrics.Domain.Converters;
using AspnetCore.Healthchecks.Metrics.DomainConfigurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.Api.Healthchecks
{
    public class GarbageCollectorHealthcheck : IHealthCheck
    {
        private readonly GCInfoOptions _options;

        public GarbageCollectorHealthcheck(IOptionsMonitor<GCInfoOptions> options)
        {
            _options = options.CurrentValue;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var allocatedMemory = GC.GetTotalMemory(forceFullCollection: false);

            var gcInfo = GC.GetGCMemoryInfo();

            GCInfoOptions.MaxMemory = MemoryConverterExtensions.ConvertMemorySize(_options.Threshold);
            GCInfoOptions.AllocatedMemory = MemoryConverterExtensions.ConvertMemorySize(allocatedMemory);
            GCInfoOptions.TotalAvailableMemory = MemoryConverterExtensions.ConvertMemorySize(gcInfo.TotalAvailableMemoryBytes);

            if (allocatedMemory > _options.Threshold)
            {
                return HealthCheckResult.Degraded();
            }

            return HealthCheckResult.Healthy();
        }
    }
}
