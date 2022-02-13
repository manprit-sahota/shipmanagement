using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Shipmanagement.Repository;
using Shipmanagement.Service.Contract;
using Shipmanagement.Service.Implementation;
using Shipmanagement.Service.MappingProfiles;

namespace Shipmanagement.Service
{
    public static class ServiceDependencies
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddRepositoryLayer();

            
            services.AddTransient<IMapper, Mapper>(s =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ShipProfile>();
                });

                var mapper = new Mapper(config);
                return mapper;
            });

            services.AddTransient<IDataMapper, AutoMapperDataMapper>();

            services.AddTransient<IShipService, ShipService>();
        }
    }
}