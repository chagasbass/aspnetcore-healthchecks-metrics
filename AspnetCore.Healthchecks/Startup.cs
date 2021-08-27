using AspnetCore.Healthchecks.Metrics.Api.Configurations;
using AspnetCore.Healthchecks.Metrics.Api.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;

namespace AspnetCore.Healthchecks.Metrics.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfigurations(Configuration)
                    .AddOptionsPattern(Configuration)
                    .AddDIConfigurations()
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
            // Custom Metrics to count requests for each endpoint and the method
            //var counter = Metrics.CreateCounter("RequestCounter", " Conta a quantidade de requests dos endpoints da api", new CounterConfiguration
            //{
            //    LabelNames = new[] { "method", "endpoint" }
            //});

            //app.Use((context, next) =>
            //{
            //    counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
            //    return next();
            //});

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
