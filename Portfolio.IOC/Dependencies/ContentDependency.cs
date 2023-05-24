using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Contract;
using Portfolio.Application.Services;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Infrastructure.Repositories;

namespace Portfolio.IOC.Dependencies
{
    public static class ContentDependency
    {
        public static void AddContentDependency(this IServiceCollection services)
        {
            #region "Repositories"
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICertificationRepository, CertificationRepository>();
            services.AddScoped<ICertificationCategoryRepository, CertificationCategoryRepository>();

            services.AddScoped<IContactFormRepository, ContactFormRepository>();

            services.AddScoped<IExperienceRepository, ExperienceRepository>();

            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectCategoryRepository, ProjectCategoryRepository>();

            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            #endregion

            #region "Services"
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICertificationService, CertificationService>();
            services.AddTransient<IBlogPostService, BlogPostService>();
            services.AddTransient<IContactFormService, ContactFormService>();
            services.AddTransient<IExperienceService, ExperienceService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            #endregion
        }
    }
}
