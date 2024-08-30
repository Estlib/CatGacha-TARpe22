using CatGacha.Models;
using Microsoft.EntityFrameworkCore;

namespace CatGacha.Data
{
    public class GatchaContext : DbContext
    {
        public GatchaContext(DbContextOptions<GatchaContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<CatOwnership> CatOwnerships { get; set; }
        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<CatOwnership>().ToTable("CatOwnerships");
            modelBuilder.Entity<Cat>().ToTable("Cats");
        }
    }
}
