using BulletinBoard.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Endpoints
{
    public class PhotoEndpoints
    {
        public static async Task<IResult> AddPhoto(ApplicationDbContext db, IFormFile file, int productId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);

            return Results.Ok();
        }
    }
}
