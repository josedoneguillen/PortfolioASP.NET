using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Configurations
{
    public static class ContentConfigurationEntity
    {
        public static void AddConfigurationContentEntity(this ModelBuilder modelBuilder)
        {

            // Certification
            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certifications");
                entity.HasMany(c => c.Categories);

            });

            // Certification Categories
            modelBuilder.Entity<CertificationCategory>(entity =>
            {
                entity.ToTable("CertificationCategories");
                entity.HasMany(c => c.Certifications);

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
                entity.ToTable("ProjectCategories");
                entity.HasMany(c => c.Projects);

            });



        }
    }
}
