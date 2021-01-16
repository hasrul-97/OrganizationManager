using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shipment.DependencyInjection;
using Steeltoe.Discovery.Client;
using System.Net;

namespace Shipment
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
            DepedencyResolver.ConfigureService(services);

            services.AddControllers();

            services.AddDiscoveryClient(Configuration);
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("Version-1", new OpenApiInfo
                {
                    Version = "Version 1",
                    Title = "Shipment",
                    Description = "ASP.NET Core 3.1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseDiscoveryClient();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    context.Response.ContentType = "application/json";
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync("An internal server error has occured. Kindly try again.");
                    }
                });
            });

            app.UseSwaggerUI(_ =>
            {
                _.SwaggerEndpoint("/swagger/Version-1/swagger.json", "Shipment");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
