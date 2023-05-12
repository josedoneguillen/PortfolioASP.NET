using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Infraestructure.Context;

namespace Portfolio.IOC.Dependencies
{
    public static class ContextDependency
    {
        public static void AddContextDependency(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
