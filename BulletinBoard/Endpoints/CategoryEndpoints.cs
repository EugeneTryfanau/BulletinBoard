using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Endpoints
{
    public class CategoryEndpoints
    {
        public static async Task<List<ProductCategory>> CategoryList(ApplicationDbContext db)
        {
            return await db.Categories.ToListAsync();
        }
    }
}
