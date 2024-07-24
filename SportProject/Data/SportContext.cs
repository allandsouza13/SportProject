using Microsoft.EntityFrameworkCore;
using SportProject.Models;

namespace SportProject.Data
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Coach and Sport
            modelBuilder.Entity<Coach>()
                .HasMany(c => c.Sports)
                .WithMany(s => s.Coaches)
                .UsingEntity(j => j.ToTable("CoachSports")); // Define the junction table
        }
    }
}
