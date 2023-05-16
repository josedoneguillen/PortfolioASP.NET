using Microsoft.Extensions.DependencyInjection;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Infrastructure.Repositories;

namespace Portfolio.IOC.Dependencies
{
    public static class SecurityDependency
    {
        public static void AddSecurityDependency(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
        }
    }
}
