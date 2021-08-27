using AspnetCore.Healthchecks.Metrics.Api.Metrics;
using AspnetCore.Healthchecks.Metrics.Data.DataContexts;
using AspnetCore.Healthchecks.Metrics.Data.Repositories;
using AspnetCore.Healthchecks.Metrics.Data.Services;
using AspnetCore.Healthchecks.Metrics.Domain.Repositories;
using AspnetCore.Healthchecks.Metrics.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore.Healthchecks.Metrics.Api.Configurations
{
    public static class DIConfigurationExtensions
    {
        public static IServiceCollection AddDIConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IAddressExternalService, AddressExternalService>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddSingleton<MetricReporter>();

            return services;
        }

        public static IServiceCollection AddDataBaseConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var stringDeConexao = configuration.GetConnectionString("Database");

            services.AddDbContext<DataContext>(contexto =>
            {
                contexto
                .UseSqlServer(stringDeConexao);

            });

            return services;
        }
    }
}
