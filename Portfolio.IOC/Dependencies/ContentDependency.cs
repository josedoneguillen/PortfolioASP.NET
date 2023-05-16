using Microsoft.Extensions.DependencyInjection;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Infrastructure.Repositories;

namespace Portfolio.IOC.Dependencies
{
    public static class ContentDependency
    {
        public static void AddContentDependency(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();

            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<ICertificationCategoryRepository, CertificationCategoryRepository>();

            services.AddScoped<IContactFormRepository, ContactFormRepository>();

            services.AddScoped<IExperienceRepository, ExperienceRepository>();

            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectCategoryRepository, ProjectCategoryRepository>();

            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        }
    }
}
