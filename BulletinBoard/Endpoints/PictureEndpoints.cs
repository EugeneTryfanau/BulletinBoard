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
                var files = formFiles;
                var folderName = Path.Combine("Resources", "Pictures");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files.Any(f => f.Length == 0))
                {
                    return Results.BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Results.Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return Results.BadRequest("500 Internal server error");
            }
        }
    }
}
