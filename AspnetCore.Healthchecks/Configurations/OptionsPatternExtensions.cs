using AspnetCore.Healthchecks.Metrics.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore.Healthchecks.Metrics.Api.Configurations
{
    public static class OptionsPatternExtensions
    {
        public static IServiceCollection AddOptionsPattern(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BaseConfigurationOptions>(configuration.GetSection(BaseConfigurationOptions.BaseConfig));

            return services;
        }
    }
}
