using BulletinBoard.Common.Entity;
using BulletinBoard.Common.Models.AuthorisationModels;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Context
{
    public class ApplicationContext: DbContext
    {
        //напоминание: стандартная строка для объявления сущностей в бд для entity
        //public DbSet<class> Name => Set<class>();

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Picture> Picture { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BulletinBoardDB.db");
        }
    }
}
