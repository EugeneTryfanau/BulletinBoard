using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BulletinBoard.Endpoints
{
    public class PictureEndpoints
    {
        public static async Task<IResult> UploadPicture(ApplicationDbContext db, IFormFileCollection formFiles, int productId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null) { return Results.BadRequest(); }

            try
            {
                var files = formFiles;
                var folderName = Path.Combine("Resources", "Pictures");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Any(f => f.Length == 0))
                {
                    return Results.BadRequest();
                }
                int i = 0;
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    product.Pictures.Add(new Picture
                    {
                        IsPrimary = i == 0 ? true : false,
                        PicturePath = fullPath,
                        PublicId = dbPath,
                        ProductId = product.Id
                    });
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    i++;
                }
                db.SaveChanges();
                return Results.Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return Results.BadRequest("500 Internal server error");
            }
        }
    }
}
