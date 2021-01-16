using Microsoft.Extensions.DependencyInjection;
using Organization.Abstraction.Business;
using Organization.Abstraction.DataAccess;
using Organization.Abstraction.Repository;
using Organization.Business;
using Organization.DataAccess;
using Organzation.Repository;

namespace Organzation.DependencyInjection
{
    public class DependencyResolver
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IOrganizationHandler, OrganizationHandler>();
            services.AddScoped<IOrganizationDataHandler, OrganizationDataHandler>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
