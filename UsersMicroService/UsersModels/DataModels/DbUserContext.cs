using DbUserService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersModels.DataModels
{
    public class DbUserContext : DbContext
    {
        public DbUserContext(DbContextOptions<DbUserContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
