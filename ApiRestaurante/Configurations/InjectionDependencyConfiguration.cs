using ApiRestaurante.Data.ConfigurationBD;
using ApiRestaurante.Data.Models;
using ApiRestaurante.Domain.Repositories;
using ApiRestaurante.Domain.Repositories.Impl;
using ApiRestaurante.Services;
using ApiRestaurante.Services.Impl;
using ApiRestaurante.Services.Mappers.Profiles;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Configurations
{
    public static class InjectionDependencyConfiguration
    {

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<DataBaseContext>(opt =>
            {
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddAutoMapper(typeof(OrdenProfile));

            services.AddScoped<IRepositoryAsync<Customer>, RepositoryAsyncImpl<Customer>>();
            services.AddScoped<IRepositoryAsync<Orden>, RepositoryAsyncImpl<Orden>>();

            services.AddScoped<IOrdenService, OrdenServiceImpl>();
            services.AddScoped<ICustomerService, CustomerServiceImpl>();

            return services;
        }

    }
}
