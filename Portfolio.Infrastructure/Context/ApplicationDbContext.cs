﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities.Security;
using Portfolio.Infrastructure.Configurations;

namespace Portfolio.Infrastructure.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        { 
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfigurationSecurityEntity();
            modelBuilder.AddConfigurationContentEntity();
            base.OnModelCreating(modelBuilder);
        }
    }
}
