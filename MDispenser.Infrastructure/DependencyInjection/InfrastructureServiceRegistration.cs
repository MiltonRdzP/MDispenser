

using MDispenser.Domain.Interfaces;
using MDispenser.Infrastructure.Persistence;
using MDispenser.Infrastructure.Persistence.Configurations;
using MDispenser.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDispenser.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<ITimeProvider, TimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
