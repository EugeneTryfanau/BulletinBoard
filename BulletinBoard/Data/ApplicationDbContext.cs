using BulletinBoard.Common.Entity;
using BulletinBoard.Common.Models.AuthorisationModels;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProductCategory> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Picture> Pictures { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
