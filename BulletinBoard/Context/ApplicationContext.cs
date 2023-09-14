using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
    }
}
