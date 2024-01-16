namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(gnyang.samples.application.Queries.GetProductSummaryWithPaginationQueryHandler).Assembly));
            return services;
        }
    }
}