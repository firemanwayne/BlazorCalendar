using CalendarUI.Presentation;
using Components.Interops;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegistryExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Config)
        {
            services.AddScoped<CustomNavInterop>();

            services.AddScoped(sp =>
            {
                return new CalendarDbContext(Config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            return services;
        }
    }
}