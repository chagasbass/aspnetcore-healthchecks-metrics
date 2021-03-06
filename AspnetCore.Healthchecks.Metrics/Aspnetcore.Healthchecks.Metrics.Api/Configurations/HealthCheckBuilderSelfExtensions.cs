using AspnetCore.Healthchecks.Metrics.Api.Healthchecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;

namespace AspnetCore.Healthchecks.Metrics.Api.Configurations
{
    /// <summary>
    /// Extensão para verificar a saúde da própria aplicação.
    /// </summary>
    public static class HealthCheckBuilderSelfExtensions
    {
        public static IHealthChecksBuilder AddSelfCheck(this IHealthChecksBuilder builder, string name, HealthStatus? failureStatus = null, IEnumerable<string> tags = null)
        {
            // Register a check of type SelfHealthCheck
            builder.AddCheck<SelfHealthCheck>(name, failureStatus ?? HealthStatus.Degraded, tags);

            return builder;
        }
    }
}
