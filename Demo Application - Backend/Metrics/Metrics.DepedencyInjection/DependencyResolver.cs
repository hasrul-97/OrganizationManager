using Metrics.Abstraction.Business;
using Metrics.Abstraction.DataAccess;
using Metrics.Abstraction.Repository;
using Metrics.Business;
using Metrics.DataAccess;
using Metrics.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.DepedencyInjection
{
    public class DependencyResolver
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IMetricsHandler, MetricsHandler>();
            services.AddScoped<IMetricsDataHandler, MetricsDataHandler>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
