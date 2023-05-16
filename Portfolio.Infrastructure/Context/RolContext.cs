﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities.Security;

namespace Portfolio.Infrastructure.Context
{
    public partial class ApplicationDbContext
    {
        public DbSet<Rol> Rols { get; set; }
    }
}
