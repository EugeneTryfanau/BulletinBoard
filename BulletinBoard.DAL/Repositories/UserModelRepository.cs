using BulletinBoard.Common.Entity;
using BulletinBoard.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.Repositories
{
    public class UserModelRepository //: IUserModelRepository
    {
        //public async Task<ApplicationUser> CreateAsync(ApplicationUser item)
        //{
        //    using (var db = new AuthorizationDbContext())
        //    {
        //        ApplicationUser userModel = item;

        //        await db.Users.AddAsync(userModel);

        //        await db.SaveChangesAsync();

        //        return userModel;
        //    }
        //}

        //public async Task<int> DeleteAsync(Guid id)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var delCount = await db.Database.ExecuteSqlRawAsync("delete from Users where Id={0}", id.ToString());

        //        await db.SaveChangesAsync();

        //        return delCount;
        //    }
        //}

        //public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var users = await db.Users.ToListAsync();

        //        return users;
        //    }
        //}

        //public async Task<ApplicationUser> GetItemByIdAsync(Guid id)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        ApplicationUser? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

        //        return user;
        //    }
        //}

        //public async Task UpdateAsync(ApplicationUser item)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var userToChange = await db.Users.FirstOrDefaultAsync(u => u.Id == item.Id.ToString());

        //        if (userToChange != null)
        //        {
        //            userToChange.UserName = item.UserName;
        //            userToChange.Email = item.Email;
        //            userToChange.Sex = item.Sex;
        //            userToChange.AvatarPictureID = item.AvatarPictureID;
        //            userToChange.PhoneNumber = item.PhoneNumber;
        //            userToChange.BirthDate = item.BirthDate;
        //            userToChange.City = item.City;

        //            await db.SaveChangesAsync();
        //        }
        //    }
        //}
    }
}
