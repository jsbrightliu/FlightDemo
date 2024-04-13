using Flight.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Services;

public static class ServiceDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAirportService, AirportService>();
        
        return services;
    }
}