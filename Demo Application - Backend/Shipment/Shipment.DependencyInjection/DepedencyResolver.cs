using Microsoft.Extensions.DependencyInjection;
using Shipment.Abstraction.Business;
using Shipment.Abstraction.DataAccess;
using Shipment.Abstraction.Repository;
using Shipment.Business;
using Shipment.DataAccess;
using Shipment.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipment.DependencyInjection
{
    public class DepedencyResolver
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IShipmentHandler, ShipmentHandler>();
            services.AddScoped<IShipmentDataHandler, ShipmentDataHandler>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
