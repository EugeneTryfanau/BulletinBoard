using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using BulletinBoard.Services;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Endpoints
{
    public class PhotoEndpoints
    {
        public static async Task<IResult> AddPhoto(ApplicationDbContext db, PhotoService photoService, IFormFile file, int productId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if (result.Error != null)
            {
                return Results.BadRequest(result.Error.Message);
            }
            var product = await db.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return Results.BadRequest("Wrong productId");
            }

            var photo = new Photo
            {
                PicturePath = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (product.Photos.Count == 0)
            {
                photo.IsPrimary = true;
            }

            product.Photos.Add(photo);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
