using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Contract;
using Portfolio.Application.Services;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Infrastructure.Repositories;

namespace Portfolio.IOC.Dependencies
{
    public static class SecurityDependency
    {
        public static void AddSecurityDependency(this IServiceCollection services)
        {
            // Repositories
            #region "Repositories"
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            #endregion

            #region "Services"
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
