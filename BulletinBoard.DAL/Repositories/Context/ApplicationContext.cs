using BulletinBoard.Common.Entity;
using BulletinBoard.Common.Models.AuthorisationModels;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.Repositories.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; } = null!;

        public DbSet<ProductCategory> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Picture> Pictures { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = Guid.NewGuid().ToString(), UserName = "Administrator", City = "NaN", PasswordHash = "Flzhk9483ELod".GetHashCode().ToString() }
        );
        }
    }
}
