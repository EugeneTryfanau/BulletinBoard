using Azure.Core;
using BulletinBoard.DAL.Data;
using System.Net.Http.Headers;

namespace BulletinBoard.Endpoints
{
    public class PictureEndpoints
    {
        public static async Task<IResult> UploadPicture(ApplicationDbContext db, IFormFileCollection formFiles)
        {
            try
            {
                var file = formFiles.First();
                var folderName = Path.Combine("Resources", "Pictures");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Results.Ok(new { dbPath });
                }
                else
                {
                    return Results.BadRequest();
                }
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
