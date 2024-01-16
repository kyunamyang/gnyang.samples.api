using Microsoft.Extensions.Configuration;
using gnyang.samples.infrastructure;
using gnyang.samples.infrastructure.Interfaces;
using gnyang.samples.infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

            //services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            //services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}