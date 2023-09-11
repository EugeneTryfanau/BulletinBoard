using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Context
{
    public class ApplicationContext: DbContext
    {
        //напоминание: стандартная строка для объявления сущностей в бд для entity
        //public DbSet<> Name => Set<>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BulletinBoardDB.db");
        }
    }
}
