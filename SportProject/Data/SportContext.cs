using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;
using SportProject.Models;

namespace SportProject.Data
{
    public class SportContext : DbContext
    {
        public SportContext (DbContextOptions<SportContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().ToTable("Sports");
            modelBuilder.Entity<Fixture>().ToTable("Fixtures");
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public DbSet<ContosoUniversity.Models.User> User { get; set; } = default!;
    }
}
