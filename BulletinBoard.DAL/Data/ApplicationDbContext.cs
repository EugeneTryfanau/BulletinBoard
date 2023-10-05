using BulletinBoard.DAL.Entity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BulletinBoard.DAL.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<ProductCategory> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Picture> Pictures { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "user", NormalizedName = "USER" }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory() { Id = 1, CategoryName = "Недвижимость" },
                new ProductCategory() { Id = 2, CategoryName = "Авто и транспорт" },
                new ProductCategory() { Id = 3, CategoryName = "Хобби, спорт и туризм" },
                new ProductCategory() { Id = 4, CategoryName = "Ремонт и стройка" },
                new ProductCategory() { Id = 5, CategoryName = "Для детей и мам" },
                new ProductCategory() { Id = 6, CategoryName = "Женский гардероб" },
                new ProductCategory() { Id = 7, CategoryName = "Мужской гардероб" },
                new ProductCategory() { Id = 8, CategoryName = "Животные" },
                new ProductCategory() { Id = 9, CategoryName = "Все для дома" },
                new ProductCategory() { Id = 10, CategoryName = "Сад и огород" },
                new ProductCategory() { Id = 11, CategoryName = "Электроника" },
                new ProductCategory() { Id = 12, CategoryName = "Телефоны и планшеты" },
                new ProductCategory() { Id = 13, CategoryName = "Компьютерная техника" },
                new ProductCategory() { Id = 14, CategoryName = "Бытовая техника" },
                new ProductCategory() { Id = 15, CategoryName = "Красота и здоровье" }
            );
        }
    }
}