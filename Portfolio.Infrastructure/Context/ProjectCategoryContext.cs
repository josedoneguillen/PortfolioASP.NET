using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Context
{
    public partial class ApplicationDbContext
    {
        public DbSet<ProjectCategory> ProjectsCategories { get; set; }
    }
}
