using Microsoft.Extensions.DependencyInjection;
using Portfolio.Infraestructure.Interfaces;
using Portfolio.Infraestructure.Repositories;

namespace Portfolio.IOC.Dependencies
{
    public static class SecurityDependency
    {
        public static void AddSecurityDependency(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
