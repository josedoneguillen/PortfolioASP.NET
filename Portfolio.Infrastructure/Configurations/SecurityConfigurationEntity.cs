using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities.Security;

namespace Portfolio.Infrastructure.Configurations
{
    public static class SecurityConfigurationEntity
    {
        public static void AddConfigurationSecurityEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Call the SetBaseProperties method from BaseConfigurationEntity
                BaseConfigurationEntity.SetBaseProperties<User>(entity);

            });

            // Roles table
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(255);

                // Call the SetBaseProperties method from BaseConfigurationEntity
                BaseConfigurationEntity.SetBaseProperties<Rol>(entity);
            });



        }
    }
}
