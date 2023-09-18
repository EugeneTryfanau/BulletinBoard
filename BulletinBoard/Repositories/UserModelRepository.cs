using BulletinBoard.DAL.Common.Models.AuthorisationModels;
using BulletinBoard.DAL.Context;
using BulletinBoard.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.DAL.Repositories
{
    public class UserModelRepository: IUserModelRepository
    {
        public async Task<UserModel> CreateAsync(UserModel item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                UserModel userModel = item;

                await db.Users.AddAsync(userModel);

                await db.SaveChangesAsync();

                return userModel;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var delCount = await db.Database.ExecuteSqlRawAsync("delete from Users where Id={0}", id.ToString());

                await db.SaveChangesAsync();

                return delCount;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = await db.Users.ToListAsync();

                return users;
            }
        }

        public async Task<UserModel> GetItemByIdAsync(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                UserModel? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

                return user;
            }
        }

        public async Task UpdateAsync(UserModel item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var userToChange = await db.Users.FirstOrDefaultAsync(u => u.Id == item.Id.ToString());

                if (userToChange != null)
                {
                    userToChange.UserName = item.UserName;
                    userToChange.Email = item.Email;
                    userToChange.Sex = item.Sex;
                    userToChange.AvatarPictureID = item.AvatarPictureID;
                    userToChange.PhoneNumber = item.PhoneNumber;
                    userToChange.BirthDate = item.BirthDate;
                    userToChange.City = item.City;

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
