using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Configurations
{
    public static class ContentConfigurationEntity
    {
        public static void AddConfigurationContentEntity(this ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.Property(e => e.Name);
                entity.Property(e => e.Description);

            });

            // Certification
            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certifications");
                entity.Property(c => c.Title);

            });

            // Certification Categories
            modelBuilder.Entity<CertificationCategory>(entity =>
            {
                entity.ToTable("CertificationsCategories");
                entity.Property(c => c.CertificationId);

            });

            // Project
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects");
                entity.HasMany(c => c.Categories);

            });

            // Project Categories
            modelBuilder.Entity<ProjectCategory>(entity =>
            {
                entity.ToTable("ProjectsCategories");
                entity.Property(c => c.ProjectId);

            });



        }
    }
}
