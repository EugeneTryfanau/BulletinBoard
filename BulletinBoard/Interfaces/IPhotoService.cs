using CloudinaryDotNet.Actions;

namespace BulletinBoard.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);
    }
}
