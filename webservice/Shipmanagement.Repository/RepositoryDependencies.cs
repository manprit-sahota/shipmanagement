using Microsoft.Extensions.DependencyInjection;
using Shipmanagement.Repository.Contract;
using Shipmanagement.Repository.Implementation;

namespace Shipmanagement.Repository
{
    public static class RepositoryDependencies
    {
        public static void AddRepositoryLayer(this IServiceCollection services)
        {
            // INFO:: This can be changed when real database integration is required
            services.AddTransient<IDataContext, StaticListDataContext>();

            // INFO:: All the new repositories need to be registered here before usage
            services.AddTransient<IShipRepository, ShipRepository>();
        }
    }
}