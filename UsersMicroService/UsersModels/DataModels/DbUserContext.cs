
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
        public DbSet<UsuarioAcceso> UsuarioAcceso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Documento)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.KeyUsuario)
                .IsUnique();

            modelBuilder.Entity<UsuarioAcceso>().HasData(new UsuarioAcceso
            {
                Id = 1,
                Username = "admin",
                Email = "admin@example.com",
                Password = "admin"
            });
        }
    }
}
