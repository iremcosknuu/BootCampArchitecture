using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer
                            (configuration.GetConnectionString("rentACarConnectionString")));

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IColorRepository, ColorRespository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<ITransmissionRepository,TransmissionRepository>();
            services.AddScoped<IFuelRepository, FuelRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();

            return services;
        }
    }
}
