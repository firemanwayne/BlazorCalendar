using Components.Interops;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegistryExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CustomNavInterop>();

            return services;
        }
    }
}