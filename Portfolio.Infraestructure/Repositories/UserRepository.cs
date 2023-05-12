using System;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities.Security;
using Portfolio.Infraestructure.Context;
using Portfolio.Infraestructure.Core;
using Portfolio.Infraestructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}

