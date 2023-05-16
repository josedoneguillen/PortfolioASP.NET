using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Core;

namespace Portfolio.Infrastructure.Configurations
{
    public static class BaseConfigurationEntity
    {
        public static void SetBaseProperties<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : BaseEntity
        {
            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            entity.Property(e => e.IsPublished)
                .HasColumnName("IsPublished")
                .IsRequired();

            entity.Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .IsRequired();

            entity.Property(e => e.IdUserModification)
                .HasColumnName("IdUserModification")
                .HasColumnType("int");

            entity.Property(e => e.IdUserCreate)
                .HasColumnName("IdUserCreate")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.IdUserDelete)
                .HasColumnName("IdUserDelete");

            entity.Property(e => e.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.ModificationDate)
                .HasColumnName("ModificationDate")
                .HasColumnType("datetime");

            entity.Property(e => e.DeletedDate)
                .HasColumnName("DeletedDate")
                .HasColumnType("datetime");
        }
    }
}
