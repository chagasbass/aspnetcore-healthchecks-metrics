using AspnetCore.Healthchecks.Metrics.Api.Configurations;
using AspnetCore.Healthchecks.Metrics.Api.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;

namespace Aspnetcore.Healthchecks.Metrics.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfigurations(Configuration)
                    .AddOptionsPattern(Configuration)
                    .AddDIConfigurations()
                    .AddAutomapperConfiguration()
                    .ConfigureHealthChecks();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspnetCore.Healthchecks", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspnetCore.Healthchecks v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            #region devem ser add depois do UseRouting
            app.UseMetricServer();
            //deve ser add depois do middleware acima

            app.UseMiddleware<ResponseMetricMiddleware>();

            app.UseHttpMetrics();
            #endregion

            app.UseAuthorization();

            app.UseHealthChecks();
            app.UserHealthCheckUi();

            //add arquivos estáticos
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/monitor");
                endpoints.MapMetrics();
            });
        }
    }
}
