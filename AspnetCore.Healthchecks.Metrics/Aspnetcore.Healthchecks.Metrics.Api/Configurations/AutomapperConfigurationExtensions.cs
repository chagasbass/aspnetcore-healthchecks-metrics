using AspnetCore.Healthchecks.Metrics.ApplicationServices.Factories.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore.Healthchecks.Metrics.Api.Configurations
{
    public static class AutomapperConfigurationExtensions
    {
        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDtoProfile));

            return services;
        }
    }
}
