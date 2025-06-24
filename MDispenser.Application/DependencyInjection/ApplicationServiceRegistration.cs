using MDispenser.Application.Abstractions;
using MDispenser.Application.Interfaces;
using MDispenser.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MDispenser.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}